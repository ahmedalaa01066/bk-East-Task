using EasyTask.Common.Endpoints;
using EasyTask.Features.PermissionRequests.SecondApprovePermissionRequest.Orchestrator;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PermissionRequests.SecondApprovePermissionRequest
{
    public class SecondApprovePermissionRequestEndpoint : EndpointBase<SecondApprovePermissionRequestRequestViewModel,SecondApprovePermissionRequestResponseViewModel>
    {
        public SecondApprovePermissionRequestEndpoint(EndpointBaseParameters<SecondApprovePermissionRequestRequestViewModel> dependencyCollection) 
            : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.SecondApprovePermissionRequest })]
        public async Task<EndPointResponse<SecondApprovePermissionRequestResponseViewModel>> 
            SecondApprovePermissionRequest(SecondApprovePermissionRequestRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<SecondApprovePermissionRequestOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<SecondApprovePermissionRequestResponseViewModel>.Success(new SecondApprovePermissionRequestResponseViewModel(),
                    "Permission Request Approved Successfully");
            else
                return EndPointResponse<SecondApprovePermissionRequestResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}