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

namespace EasyTask.Features.PermissionRequests.GetAllPermissionRequests
{
    public class GetAllPermissionRequestsEndpoint : EndpointBase<GetAllPermissionRequestsRequestViewModel, GetAllPermissionRequestsResponseViewModel>
    {
        public GetAllPermissionRequestsEndpoint(EndpointBaseParameters<GetAllPermissionRequestsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllPermissionRequests })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllPermissionRequestsResponseViewModel>>>> GetAllPermissionRequests([FromQuery] GetAllPermissionRequestsRequestViewModel filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllPermissionRequestsQuery>());
            var response = result.Data.MapPage<GetAllPermissionRequestsDTO, GetAllPermissionRequestsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllPermissionRequestsResponseViewModel>>
                    .Success(response, "Employee Permission Requests got successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllPermissionRequestsResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
