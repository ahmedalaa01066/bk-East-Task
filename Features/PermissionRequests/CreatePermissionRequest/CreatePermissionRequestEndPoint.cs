using EasyTask.Common.Endpoints;
using EasyTask.Features.PermissionRequests.CreatePermissionRequest.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PermissionRequests.CreatePermissionRequest
{
    public class CreatePermissionRequestEndPoint : EndpointBase<CreatePermissionRequestRequestViewModel, CreatePermissionRequestResponseViewModel>
    {
        public CreatePermissionRequestEndPoint(EndpointBaseParameters<CreatePermissionRequestRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreatePermissionRequest })]
        public async Task<EndPointResponse<CreatePermissionRequestResponseViewModel>> CreatePermissionRequest(CreatePermissionRequestRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreatePermissionRequestCommand>());
            if (result.IsSuccess)
                return EndPointResponse<CreatePermissionRequestResponseViewModel>.Success(new CreatePermissionRequestResponseViewModel(), "Permission Request Added Successfully");
            else
                return EndPointResponse<CreatePermissionRequestResponseViewModel>.Failure(result.ErrorCode, result.Message);
        }
    }
}
