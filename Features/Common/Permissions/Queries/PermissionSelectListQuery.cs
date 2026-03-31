using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.Permissions;

namespace EasyTask.Features.Common.Permissions.Queries
{
    public record PermissionSelectListQuery():IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class PermissionSelectListQueryHandler : RequestHandlerBase<Permission, PermissionSelectListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public PermissionSelectListQueryHandler(RequestHandlerBaseParameters<Permission> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(PermissionSelectListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = _repository.Get().ToSelectListViewModel();

            if (selectListItems == null || !selectListItems.Any())
            {
                return RequestResult<IEnumerable<SelectListItemViewModel>>
                    .Failure(ErrorCode.NotFound,"No permissions found.");
            }
            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);
        }
    }
}
