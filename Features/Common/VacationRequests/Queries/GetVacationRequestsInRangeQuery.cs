using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.VacationRequests;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.VacationRequests.Queries
{
    public record GetVacationRequestsInRangeQuery(DateOnly StartDate, DateOnly EndDate)
        : IRequestBase<List<VacationRequest>>;
    public class GetVacationRequestsInRangeQueryHandler : RequestHandlerBase<VacationRequest, GetVacationRequestsInRangeQuery, List<VacationRequest>>
    {
        public GetVacationRequestsInRangeQueryHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<VacationRequest>>> Handle(GetVacationRequestsInRangeQuery request, CancellationToken cancellationToken)
        {
            var result =  _repository.Get()
                          .Include(v => v.Vacation)
                          .Where(vr =>
                              vr.VacationRequestStatus == RequestStatus.SecondApproval &&
                              vr.ToDate >= request.StartDate && vr.FromDate <= request.EndDate).ToList();

            return RequestResult<List< VacationRequest >>.Success(result);
        }
    }
}
