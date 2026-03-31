using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.PermissionRequests;

namespace EasyTask.Features.Common.PermissionRequests.Queries
{
    public record CheckSecondPermissionForCandidateForLeaveQuery(string candidateId) : IRequestBase<bool>;
    public class CheckSecondPermissionForCandidateForLeaveQueryHandler : RequestHandlerBase<PermissionRequest, CheckSecondPermissionForCandidateForLeaveQuery, bool>
    {
        public CheckSecondPermissionForCandidateForLeaveQueryHandler(RequestHandlerBaseParameters<PermissionRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CheckSecondPermissionForCandidateForLeaveQuery request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(p => p.CandidateId == request.candidateId
            && p.Date == DateOnly.FromDateTime(DateTime.Now)
            && p.FromTime <= DateTime.Now.TimeOfDay
            && p.PermissionRequestStatus == RequestStatus.SecondApproval);
            return RequestResult<bool>.Success(check);
        }
    }
}
