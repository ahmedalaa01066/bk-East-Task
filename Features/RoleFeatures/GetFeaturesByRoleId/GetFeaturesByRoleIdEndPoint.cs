using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.RoleFeatures.GetFeaturesByRoleId;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.RoleFeatures.GetFeaturesByRoleId
{
    public class GetFeaturesByRoleIdEndPoint : EndpointBase<GetFeaturesByRoleIdRequestViewModel, GetFeaturesByRoleIdResponseViewModel>
    {
        public GetFeaturesByRoleIdEndPoint(EndpointBaseParameters<GetFeaturesByRoleIdRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetModulesbyRoleID })]
        public async Task<EndPointResponse<GetFeaturesByRoleIdResponseViewModel>> GetModulesByRoleId([FromQuery] GetFeaturesByRoleIdRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<GetFeaturesByRoleIdQuery>());

            var response = result.Data.MapOne<GetFeaturesByRoleIdResponseViewModel>();

            return EndPointResponse<GetFeaturesByRoleIdResponseViewModel>
                .Success(response, "Features retrieved successfully.");
        }
    }
}
