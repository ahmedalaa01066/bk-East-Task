using EasyTask.Common.Requests;
using EasyTask.Models.SpecialDays;

namespace EasyTask.Features.Common.SpecialDays.Queries
{
    public record GetSpecialDaysInRangeQuery(DateOnly StartDate, DateOnly EndDate)
        : IRequestBase<List<SpecialDay>>;
    public class GetSpecialDaysInRangeQueryHandler : RequestHandlerBase<SpecialDay, GetSpecialDaysInRangeQuery, List<SpecialDay>>
    {
        public GetSpecialDaysInRangeQueryHandler(RequestHandlerBaseParameters<SpecialDay> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<SpecialDay>>> Handle(GetSpecialDaysInRangeQuery request, CancellationToken cancellationToken)
        {
            var weekDays = Enumerable.Range(0, 7).Select(i => request.StartDate.AddDays(i)).ToList();

            var result =  _repository
                .Get(sd =>
                    (sd.IsOneDay && weekDays.Contains(sd.FromDate)) ||
                    (!sd.IsOneDay && sd.ToDate >= request.StartDate && sd.FromDate <= weekDays.Last()))
                .ToList();

            return RequestResult<List<SpecialDay>>.Success(result);
        }
    }
}
