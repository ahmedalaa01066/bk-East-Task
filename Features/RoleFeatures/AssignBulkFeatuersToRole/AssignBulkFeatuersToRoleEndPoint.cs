using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.RoleFeatures.AssignBulkFeaturesToRole.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;

namespace EasyTask.Features.RoleFeatures.AssignBulkFeatuersToRole
{
    public class AssignBulkFeatuersToRoleEndPoint : EndpointBase<AssignBulkFeatuersToRoleRequestViewModel, AssignBulkFeatuersToRoleResponseViewModel>
    {
        public AssignBulkFeatuersToRoleEndPoint(EndpointBaseParameters<AssignBulkFeatuersToRoleRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AssignBulkFeaturesToRole })]
        public async Task<EndPointResponse<AssignBulkFeatuersToRoleResponseViewModel>> AssignBulkFeaturesToRole(AssignBulkFeatuersToRoleRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<AssignBulkFeatuersToRoleOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<AssignBulkFeatuersToRoleResponseViewModel>.Success(new AssignBulkFeatuersToRoleResponseViewModel(), "Bulk Features Assigned To Role successfully");
            else
                return EndPointResponse<AssignBulkFeatuersToRoleResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
