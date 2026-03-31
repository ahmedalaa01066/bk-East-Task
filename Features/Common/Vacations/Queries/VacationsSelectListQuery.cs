using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.Vacations;

namespace EasyTask.Features.Common.Vacations.Queries
{
    public record VacationsSelectListQuery():IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class VacationsSelectListQueryHandler : RequestHandlerBase<Vacation, VacationsSelectListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public VacationsSelectListQueryHandler(RequestHandlerBaseParameters<Vacation> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(VacationsSelectListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = _repository.Get().ToSelectListViewModel();

            if (selectListItems == null || !selectListItems.Any())
            {
                return RequestResult<IEnumerable<SelectListItemViewModel>>
                    .Failure(ErrorCode.NotFound, "No Vacations found.");
            }
            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);
        }
    }
}
