using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.VacationRequests;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.VacationRequests.Queries
{
    public record GetTodayVacationNumberQuery() : IRequestBase<int>;
    public class GetTodayVacationNumberQueryHandler : RequestHandlerBase<VacationRequest, GetTodayVacationNumberQuery, int>
    {
        public GetTodayVacationNumberQueryHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<int>> Handle(GetTodayVacationNumberQuery request, CancellationToken cancellationToken)
        {
            var count = await _repository.Get(vr =>
                    vr.VacationRequestStatus == RequestStatus.SecondApproval &&
                    vr.Vacation.IsSpecial == null &&
                    DateOnly.FromDateTime(DateTime.Now) == vr.FromDate)
                .Include(vr => vr.Vacation)
                .CountAsync();
            return RequestResult<int>.Success(count);
        }
    }
}
