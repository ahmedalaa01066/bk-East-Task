using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.PermissionRequests.Queries;
using EasyTask.Features.PermissionRequests.GetPermissionRequestById;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PermissionRequests.GetByIdPermissionRequest
{
    public class GetPermissionRequestByIdEndpoint : EndpointBase<GetPermissionRequestByIdRequestViewModel, GetPermissionRequestByIdResponseViewModel>
    {
        public GetPermissionRequestByIdEndpoint(EndpointBaseParameters<GetPermissionRequestByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetPermissionRequestByID })]
        public async Task<EndPointResponse<GetPermissionRequestByIdResponseViewModel>> GetPermissionRequestByID([FromQuery] GetPermissionRequestByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetPermissionRequestByIdQuery>());

            var response = result.Data.MapOne<GetPermissionRequestByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetPermissionRequestByIdResponseViewModel>.Success(response, "Get Permission Request successfully.");
            else
                return EndPointResponse<GetPermissionRequestByIdResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
