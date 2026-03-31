using EasyTask.Common.Endpoints;
using EasyTask.Features.PermissionRequests.FirstApprovePermissionRequest.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PermissionRequests.FirstApprovePermissionRequest
{
    public class FirstApprovePermissionRequestEndPoint : EndpointBase<FirstApprovePermissionRequestRequestViewModel, FirstApprovePermissionRequestResponseViewModel>
    {
        public FirstApprovePermissionRequestEndPoint(EndpointBaseParameters<FirstApprovePermissionRequestRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.FirstApprovePermissionRequest })]
        public async Task<EndPointResponse<FirstApprovePermissionRequestResponseViewModel>> FirstApprovePermissionRequest(FirstApprovePermissionRequestRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<FirstApprovePermissionRequestCommand>());
            if (result.IsSuccess)
                return EndPointResponse<FirstApprovePermissionRequestResponseViewModel>.Success(new FirstApprovePermissionRequestResponseViewModel(), "Permission Request Approved Successfully");
            else
                return EndPointResponse<FirstApprovePermissionRequestResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
