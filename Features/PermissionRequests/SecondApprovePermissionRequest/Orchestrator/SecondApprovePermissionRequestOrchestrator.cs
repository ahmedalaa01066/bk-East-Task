using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.CandidatePermissions.CreateCandidatePermission.Commands;
using EasyTask.Features.Common.CandidatePermissions.Queries;
using EasyTask.Features.PermissionRequests.SecondApprovePermissionRequest.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.PermissionRequests;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.PermissionRequests.SecondApprovePermissionRequest.Orchestrator
{
    public record SecondApprovePermissionRequestOrchestrator(string ID):IRequestBase<bool>;
    public class SecondApprovePermissionRequestOrchestratorHandler : RequestHandlerBase<PermissionRequest, SecondApprovePermissionRequestOrchestrator, bool>
    {
        public SecondApprovePermissionRequestOrchestratorHandler(RequestHandlerBaseParameters<PermissionRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(SecondApprovePermissionRequestOrchestrator request, CancellationToken cancellationToken)
        {
            //var roleId = _userState.RoleID;
            //if (roleId != Role.HR)
            //{
            //    return RequestResult<bool>.Failure(ErrorCode.Unauthorize, "Only HR is authorized to approve Permission requests.");
            //}
            var PermissionRequest = await _repository.Get(pr => pr.ID == request.ID).Include(pr => pr.Permission).FirstOrDefaultAsync();
            if (PermissionRequest == null) 
            { 
              return RequestResult<bool>.Failure(ErrorCode.NotFound);
            }

            if (PermissionRequest.PermissionRequestStatus != RequestStatus.FirstApproval)
            {
                return RequestResult<bool>.Failure(ErrorCode.ManagerApprovalRequired);
            }

            TimeSpan numOfHoursOfPermission = PermissionRequest.ToTime - PermissionRequest.FromTime;
            TimeSpan MaxHoursPerMonth = TimeSpan.FromHours(PermissionRequest.Permission.MaxHoursPerMonth);

            if(MaxHoursPerMonth < numOfHoursOfPermission)
            {
                return RequestResult<bool>.Failure(ErrorCode.ExccededPermissionTime);
            }
            var existingCandidatePermission = await _mediator.Send(new CheckCandidatePermissionsExistQuery(PermissionRequest.CandidateId, PermissionRequest.PermissionId, DateTime.Now));
            
            if (existingCandidatePermission.Data == null) 
            {
                var create = await _mediator.Send(new CreateCandidatePermissionCommand
                (
                    CandidateId: PermissionRequest.CandidateId,
                    PermissionId: PermissionRequest.PermissionId,
                    NumOfHoursOfPermission: numOfHoursOfPermission,
                    PermissionMonth : DateTime.Now,
                    HoursLeftInMonth : MaxHoursPerMonth - numOfHoursOfPermission
                ));
            }
            else
            {
                if(existingCandidatePermission.Data.HoursLeftInMonth < numOfHoursOfPermission)
                {
                    return RequestResult<bool>.Failure(ErrorCode.ExccededPermissionTime);
                }
                var edit = await _mediator.Send(new EditEditCandidatePermissionCommand
                (
                    ID: existingCandidatePermission.Data.ID,
                    NumOfHoursOfPermission: existingCandidatePermission.Data.NumOfHoursOfPermission + numOfHoursOfPermission,
                    HoursLeftInMonth: MaxHoursPerMonth - numOfHoursOfPermission
                ));
            }
            
            var ApproveRequest = await _mediator.Send(request.MapOne<SecondApprovePermissionRequestCommand>());

            if (!ApproveRequest.IsSuccess)
            {
                return RequestResult<bool>.Failure(ApproveRequest.ErrorCode, ApproveRequest.Message);
            }
            return RequestResult<bool>.Success(true);
        }
    }
}
