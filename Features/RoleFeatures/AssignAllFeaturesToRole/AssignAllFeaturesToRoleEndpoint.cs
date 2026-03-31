using EasyTask.Common.Endpoints;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.RoleFeatures.AssignAllFeaturesToRole.Commands;
using EasyTask.Helpers;

namespace EasyTask.Features.RoleFeatures.AssignAllFeaturesToRole
{
    public class AssignAllFeaturesToRoleEndpoint : EndpointBase<AssignAllFeaturesToRoleRequestViewModel, AssignAllFeaturesToRoleResponseViewModel>
    {
        public AssignAllFeaturesToRoleEndpoint(EndpointBaseParameters<AssignAllFeaturesToRoleRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AssignAllFeaturesToRole })]
        public async Task<EndPointResponse<AssignAllFeaturesToRoleResponseViewModel>> AssignAllFeaturesToRole(AssignAllFeaturesToRoleRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<AssignAllFeaturesToRoleCommand>());
            if (result.IsSuccess)
                return EndPointResponse<AssignAllFeaturesToRoleResponseViewModel>.Success(new AssignAllFeaturesToRoleResponseViewModel(), "All Features Assigned To Role successfully");
            else
                return EndPointResponse<AssignAllFeaturesToRoleResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
