using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.CandidateVacations.DeductCandidateVacationsDay.Command;
using EasyTask.Features.VacationRequests.SecondApproveVactionRequest.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.VacationRequests;

namespace EasyTask.Features.VacationRequests.SecondApproveVactionRequest.Orchestrator
{
    public record SecondApproveVacationRequestOrchestrator(string ID):IRequestBase<bool>;
    public class SecondApproveVactionRequestOrchestratorHandler : RequestHandlerBase<VacationRequest, SecondApproveVacationRequestOrchestrator, bool>
    {
        public SecondApproveVactionRequestOrchestratorHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(SecondApproveVacationRequestOrchestrator request, CancellationToken cancellationToken)
        {
            var roleId = _userState.RoleID;
            if (roleId != Role.HR)
            {
                return RequestResult<bool>.Failure(ErrorCode.Unauthorize, "Only HR is authorized to approve vacation requests.");
            }
            var vacationRequest=_repository.GetByID(request.ID);
            if (vacationRequest == null) { 
              return RequestResult<bool>.Failure(ErrorCode.NotFound);
            }

            if (vacationRequest.VacationRequestStatus!=RequestStatus.FirstApproval)
            {
                return RequestResult<bool>.Failure(ErrorCode.ManagerApprovalRequired);
            }

            var numberOfDays = (vacationRequest.ToDate.DayNumber - vacationRequest.FromDate.DayNumber) + 1;

            if (numberOfDays <= 0)
            {
                return RequestResult<bool>.Failure(ErrorCode.InvalidVacationDates, "Invalid vacation dates.");
            }

            var candidateVacation = await _mediator.Send(
                new DeductCandidateVacationsDayCommand(
                    vacationRequest.CandidateId,
                    vacationRequest.VacationId,
                    numberOfDays
                ));

            if (!candidateVacation.IsSuccess)
            {
                return RequestResult<bool>.Failure(candidateVacation.ErrorCode, candidateVacation.Message);
            }
            var ApproveRequest = await _mediator.Send(request.MapOne<SecondApproveVacationRequestCommand>());

            if (!ApproveRequest.IsSuccess)
            {
                return RequestResult<bool>.Failure(ApproveRequest.ErrorCode, ApproveRequest.Message);
            }
            return RequestResult<bool>.Success(true);
        }
    }
}
