using EasyTask.Common.Endpoints;
using EasyTask.Features.Permissions.EditPermission.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Permissions.EditPermission
{
    public class EditPermissionEndPoint : EndpointBase<EditPermissionRequestViewModel, EditPermissionResponseViewModel>
    {
        public EditPermissionEndPoint(EndpointBaseParameters<EditPermissionRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditPermission })]
        public async Task<EndPointResponse<EditPermissionResponseViewModel>> EditPermission(EditPermissionRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditPermissionCommand>());
            if (result.IsSuccess)
                return EndPointResponse<EditPermissionResponseViewModel>.Success(new EditPermissionResponseViewModel(), "Permission Updated Successfully");
            else
                return EndPointResponse<EditPermissionResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
