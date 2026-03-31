using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.Levels;

namespace EasyTask.Features.Common.Levels.Queries
{
    public record LevelSelectListQuery() :IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class LevelSelectListQueryHandler : RequestHandlerBase<Level, LevelSelectListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public LevelSelectListQueryHandler(RequestHandlerBaseParameters<Level> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(LevelSelectListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = _repository.Get().ToSelectListViewModel();
            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);
        }
    }
}
