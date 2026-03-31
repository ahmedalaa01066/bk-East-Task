using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.SpecialDays.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.SpecialDays;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.SpecialDays.Queries
{
    public record GetAllSpecialDaysQuery
        (string? Name, DateOnly? From, DateOnly? To, int pageIndex = 1, int pageSize = 100)
        : IRequestBase<PagingViewModel<GetSpecialDayByIdDTO>>;
    public class GetAllSpecialDaysQueryHandler : RequestHandlerBase<SpecialDay, GetAllSpecialDaysQuery, PagingViewModel<GetSpecialDayByIdDTO>>
    {
        public GetAllSpecialDaysQueryHandler(RequestHandlerBaseParameters<SpecialDay> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetSpecialDayByIdDTO>>> Handle(GetAllSpecialDaysQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<SpecialDay>(true);

            predicate = predicate
                .And(p => string.IsNullOrEmpty(request.Name) || p.Name.Contains(request.Name))
                .And(p => !request.From.HasValue || p.FromDate >= request.From)
                .And(p => !request.To.HasValue || p.ToDate <= request.To);

            var query = await _repository
                .Get(predicate)
                .OrderByDescending(p => p.CreatedDate)
                .Map<GetSpecialDayByIdDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetSpecialDayByIdDTO>>.Success(query);
        }
    }
}
