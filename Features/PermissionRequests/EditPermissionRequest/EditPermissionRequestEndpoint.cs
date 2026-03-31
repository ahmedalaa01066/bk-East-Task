using EasyTask.Common.Endpoints;
using EasyTask.Features.PermissionRequests.EditPermissionRequest.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PermissionRequests.EditPermissionRequest
{
    public class EditPermissionRequestEndpoint : EndpointBase<EditPermissionRequestRequestViewModel, EditPermissionRequestResponseViewModel>
    {
        public EditPermissionRequestEndpoint(EndpointBaseParameters<EditPermissionRequestRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditPermissionRequest })]
        public async Task<EndPointResponse<EditPermissionRequestResponseViewModel>> EditPermissionRequest(EditPermissionRequestRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<EditPermissionRequestCommand>());

            if (result.IsSuccess)
                return EndPointResponse<EditPermissionRequestResponseViewModel>.Success(new EditPermissionRequestResponseViewModel(), "Request Updated successfully");
            else
                return EndPointResponse<EditPermissionRequestResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
