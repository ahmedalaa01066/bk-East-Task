using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.VacationRequests;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.VacationRequests.Queries
{
    public record GetTodaySpecialVacationNumberQuery() : IRequestBase<int>;
    public class GetTodaySpecialVacationNumberQueryHandler : RequestHandlerBase<VacationRequest, GetTodaySpecialVacationNumberQuery, int>
    {
        public GetTodaySpecialVacationNumberQueryHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<int>> Handle(GetTodaySpecialVacationNumberQuery request, CancellationToken cancellationToken)
        {
            var count = await _repository.Get(vr =>
                     vr.VacationRequestStatus == RequestStatus.SecondApproval &&
                     vr.Vacation.IsSpecial == true &&
                     DateOnly.FromDateTime(DateTime.Now) == vr.FromDate)
                 .Include(vr => vr.Vacation)
                 .CountAsync();
            return RequestResult<int>.Success(count);
        }
    }
}
