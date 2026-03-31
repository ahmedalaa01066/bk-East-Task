using EasyTask.Common.Endpoints;
using EasyTask.Features.PermissionRequests.CancelPermissionRequest.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PermissionRequests.CancelPermissionRequest
{
    public class CancelPermissionRequestEndPoint : EndpointBase<CancelPermissionRequestRequestViewModel, CancelPermissionRequestResponseViewModel>
    {
        public CancelPermissionRequestEndPoint(EndpointBaseParameters<CancelPermissionRequestRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CancelPermissionRequest })]
        public async Task<EndPointResponse<CancelPermissionRequestResponseViewModel>> CancelPermissionRequest(CancelPermissionRequestRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CancelPermissionRequestCommand>());
            if (result.IsSuccess)
                return EndPointResponse<CancelPermissionRequestResponseViewModel>.Success(new CancelPermissionRequestResponseViewModel(), "Permission Request Canceled Successfully");
            else
                return EndPointResponse<CancelPermissionRequestResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
