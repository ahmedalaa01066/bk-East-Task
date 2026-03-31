using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.WorkPackages;

namespace EasyTask.Features.Common.WorkPackages.Queries
{
    public record WorkPackageSelectListQuery() :IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class WorkPackageSelectListQueryHandler : RequestHandlerBase<WorkPackage, WorkPackageSelectListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public WorkPackageSelectListQueryHandler(RequestHandlerBaseParameters<WorkPackage> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(WorkPackageSelectListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = _repository.Get().ToSelectListViewModel();
            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);
        }
    }
}
