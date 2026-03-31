using EasyTask.Common.Endpoints;
using EasyTask.Features.RoleFeatures.UnassignBulkFeaturesFromRole.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.RoleFeatures.UnassignBulkFeatuersToRole
{
    public class UnassignBulkFeatuersToRoleEndpoint : EndpointBase<UnassignBulkFeatuersToRoleRequestViewModel, UnassignBulkFeatuersToRoleResponseViewModel>
    {
        public UnassignBulkFeatuersToRoleEndpoint(EndpointBaseParameters<UnassignBulkFeatuersToRoleRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.UnassignBulkFeaturesToRole })]
        public async Task<EndPointResponse<UnassignBulkFeatuersToRoleResponseViewModel>> UnassignBulkFeaturesToRole(UnassignBulkFeatuersToRoleRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<UnassignBulkFeaturesFromRoleCommand>());
            if (result.IsSuccess)
                return EndPointResponse<UnassignBulkFeatuersToRoleResponseViewModel>.Success(new UnassignBulkFeatuersToRoleResponseViewModel(), "Bulk Features Unassigned To Role successfully");
            else
                return EndPointResponse<UnassignBulkFeatuersToRoleResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
