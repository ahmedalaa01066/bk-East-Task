using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Positions.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Positions;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Positions.Queries
{
    public record GetAllPositionsQuery(string? Name, int pageIndex = 1,
        int pageSize = 100):IRequestBase<PagingViewModel<GetAllPositionsDTO>>;
    public class GetAllPositionsQueryHandler : RequestHandlerBase<Position, GetAllPositionsQuery, PagingViewModel<GetAllPositionsDTO>>
    {
        public GetAllPositionsQueryHandler(RequestHandlerBaseParameters<Position> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllPositionsDTO>>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Position>(true);

            predicate = predicate
                .And(c => string.IsNullOrEmpty(request.Name) ? true : c.Name.Contains(request.Name));
            var query = await _repository.Get(predicate)
              .Map<GetAllPositionsDTO>()
              .ToPagesAsync(request.pageIndex, request.pageSize);
            return RequestResult<PagingViewModel<GetAllPositionsDTO>>.Success(query);
        }
    }
}
