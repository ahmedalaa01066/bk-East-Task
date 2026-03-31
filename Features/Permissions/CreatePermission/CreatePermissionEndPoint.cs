using EasyTask.Common.Endpoints;
using EasyTask.Features.Permissions.CreatePermission.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Permissions.CreatePermission
{
    public class CreatePermissionEndPoint : EndpointBase<CreatePermissionRequestViewModel, CreatePermissionResponseViewModel>
    {
        public CreatePermissionEndPoint(EndpointBaseParameters<CreatePermissionRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreatePermission })]
        public async Task<EndPointResponse<CreatePermissionResponseViewModel>> CreatePermission(CreatePermissionRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreatePermissionCommand>());
            if (result.IsSuccess)
                return EndPointResponse<CreatePermissionResponseViewModel>.Success(new CreatePermissionResponseViewModel(), "Permission Added Successfully");
            else
                return EndPointResponse<CreatePermissionResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
