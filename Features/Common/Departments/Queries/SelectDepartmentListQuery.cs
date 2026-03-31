using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.Departments;

namespace EasyTask.Features.Common.Departments.Queries
{
    public record SelectDepartmentListQuery(string? ManagementId) : IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class SelectDepartmentListQueryHandler : RequestHandlerBase<Department, SelectDepartmentListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public SelectDepartmentListQueryHandler(RequestHandlerBaseParameters<Department> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(SelectDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = _repository.Get(c => c.ManagementId == request.ManagementId).ToSelectListViewModel();
            if (request.ManagementId == null)
                selectListItems = _repository.Get().ToSelectListViewModel();
            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);
        }
    }
}
