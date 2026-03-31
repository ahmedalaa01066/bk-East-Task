using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.Positions;

namespace EasyTask.Features.Common.Positions.Queries
{
    public record PositionSelectListQuery() : IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class PositionSelectListQueryHandler : RequestHandlerBase<Position, PositionSelectListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public PositionSelectListQueryHandler(RequestHandlerBaseParameters<Position> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(PositionSelectListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = _repository.Get().ToSelectListViewModel();
            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);
        }
    }
}
