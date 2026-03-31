using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Permissions.Queries;
using EasyTask.Features.Permissions.GetPermissionById;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Permissions.GetByIdPermission
{
    public class GetPermissionByIdEndpoint : EndpointBase<GetPermissionByIdRequestViewModel, GetPermissionByIdResponseViewModel>
    {
        public GetPermissionByIdEndpoint(EndpointBaseParameters<GetPermissionByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetPermissionByID })]
        public async Task<EndPointResponse<GetPermissionByIdResponseViewModel>> GetPermissionByID([FromQuery] GetPermissionByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetPermissionByIdQuery>());

            var response = result.Data.MapOne<GetPermissionByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetPermissionByIdResponseViewModel>.Success(response, "Get Permission successfully.");
            else
                return EndPointResponse<GetPermissionByIdResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
