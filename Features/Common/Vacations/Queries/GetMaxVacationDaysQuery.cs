using EasyTask.Common.Requests;
using EasyTask.Models.Vacations;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Vacations.Queries
{
    public record GetMaxVacationDaysQuery():IRequestBase<int>;
    public class GetMaxVacationDaysQueryHandler : RequestHandlerBase<Vacation, GetMaxVacationDaysQuery, int>
    {
        public GetMaxVacationDaysQueryHandler(RequestHandlerBaseParameters<Vacation> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<int>> Handle(GetMaxVacationDaysQuery request, CancellationToken cancellationToken)
        {
            var total = await _repository.Get()
                         .SumAsync(v => v.MaxRequestNum);

            return RequestResult<int>.Success(total);
        }
    }
}
