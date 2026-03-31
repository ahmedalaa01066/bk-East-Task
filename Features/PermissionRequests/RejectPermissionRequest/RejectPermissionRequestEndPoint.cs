using EasyTask.Common.Endpoints;
using EasyTask.Features.PermissionRequests.RejectPermissionRequest.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PermissionRequests.RejectPermissionRequest
{
    public class RejectPermissionRequestEndPoint : EndpointBase<RejectPermissionRequestRequestViewModel, RejectPermissionRequestResponseViewModel>
    {
        public RejectPermissionRequestEndPoint(EndpointBaseParameters<RejectPermissionRequestRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.RejectPermissionRequest })]
        public async Task<EndPointResponse<RejectPermissionRequestResponseViewModel>> RejectPermissionRequest(RejectPermissionRequestRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<RejectPermissionRequestCommand>());
            if (result.IsSuccess)
                return EndPointResponse<RejectPermissionRequestResponseViewModel>.Success(new RejectPermissionRequestResponseViewModel(), "Permission Request Rejected Successfully");
            else
                return EndPointResponse<RejectPermissionRequestResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
