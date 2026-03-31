using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.PermissionRequests;

namespace EasyTask.Features.Common.PermissionRequests.Queries
{
    public record CheckSecondPermissionForCandidateQuery(string candidateId) : IRequestBase<bool>;
    public class CheckSecondPermissionForCandidateQueryHandler : RequestHandlerBase<PermissionRequest, CheckSecondPermissionForCandidateQuery, bool>
    {
        public CheckSecondPermissionForCandidateQueryHandler(RequestHandlerBaseParameters<PermissionRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CheckSecondPermissionForCandidateQuery request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(p => p.CandidateId == request.candidateId
            && p.Date == DateOnly.FromDateTime(DateTime.Now)
            && p.ToTime >= DateTime.Now.TimeOfDay
            && p.PermissionRequestStatus == RequestStatus.SecondApproval);
            return RequestResult<bool>.Success(check);
        }
    }
}
