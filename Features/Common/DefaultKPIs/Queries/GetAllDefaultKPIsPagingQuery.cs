using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.DefaultKPIs.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.DefaultKPIs;
using EasyTask.Models.Enums;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.DefaultKPIs.Queries
{
    public record GetAllDefaultKPIsPagingQuery(string? Name, KPIType? Type, double? Percentage, int pageIndex = 1, int pageSize = 100) : IRequestBase<PagingViewModel<GetAllDefaultKPIsDTO>>;
    public class GetAllDefaultKPIsPagingQueryHandler : RequestHandlerBase<DefaultKPI, GetAllDefaultKPIsPagingQuery, PagingViewModel<GetAllDefaultKPIsDTO>>
    {
        public GetAllDefaultKPIsPagingQueryHandler(RequestHandlerBaseParameters<DefaultKPI> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllDefaultKPIsDTO>>> Handle(GetAllDefaultKPIsPagingQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<DefaultKPI>(true);

            predicate = predicate
                .And(c => string.IsNullOrEmpty(request.Name) || c.Name.Contains(request.Name))
                .And(c => !request.Percentage.HasValue || c.Percentage == request.Percentage)
                .And(p => !request.Type.HasValue || p.Type == request.Type.Value);

            var query = await _repository
                .Get(predicate)
                 .Map<GetAllDefaultKPIsDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllDefaultKPIsDTO>>.Success(query);
        }
    }
}
