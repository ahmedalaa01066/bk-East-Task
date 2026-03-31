using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.PermissionRequests.DTOs;
using EasyTask.Features.Common.PermissionRequests.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PermissionRequests.GetAllPermissionRequestsToManager
{
    public class GetAllPermissionRequestsToManagerEndpoint : EndpointBase<GetAllPermissionRequestsToManagerRequestViewModel, GetAllPermissionRequestsToManagerResponseViewModel>
    {
        public GetAllPermissionRequestsToManagerEndpoint(EndpointBaseParameters<GetAllPermissionRequestsToManagerRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllPermissionRequestsToManager })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllPermissionRequestsToManagerResponseViewModel>>>> GetAllPermissionRequestsToManager([FromQuery] GetAllPermissionRequestsToManagerRequestViewModel filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllPermissionRequestsToManagerQuery>());
            var response = result.Data.MapPage<GetAllPermissionRequestsToManagerDTO, GetAllPermissionRequestsToManagerResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllPermissionRequestsToManagerResponseViewModel>>
                    .Success(response, "Employee Permission Requests got successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllPermissionRequestsToManagerResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
