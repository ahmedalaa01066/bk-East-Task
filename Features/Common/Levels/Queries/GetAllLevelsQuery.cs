using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Levels.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Levels;
using System.Linq;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Levels.Queries
{
    public record GetAllLevelsQuery(string? Name,  int pageIndex = 1, int pageSize = 100) : IRequestBase<PagingViewModel<GetAllLevelsDTO>>;

    public class GetAllLevelIndexQueryHandler : RequestHandlerBase<Level, GetAllLevelsQuery, PagingViewModel<GetAllLevelsDTO>>
    {
        public GetAllLevelIndexQueryHandler(RequestHandlerBaseParameters<Level> requestParameters) : base(requestParameters)
        {
        }
        public async override Task<RequestResult<PagingViewModel<GetAllLevelsDTO>>> Handle(GetAllLevelsQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Level>(true);

            predicate = predicate
                .And(c => string.IsNullOrEmpty(request.Name) || c.Name.Contains(request.Name));

            var query = await _repository
                .Get(predicate)
                 .Map<GetAllLevelsDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllLevelsDTO>>.Success(query);
        }

    }
}
