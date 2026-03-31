using EasyTask.Common.Endpoints;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Users.BulkDeActivateUser.Orchestrator;
using EasyTask.Helpers;

namespace EasyTask.Features.Users.BulkDeActivateUser
{
    public class BulkDeActivateUserEndPoint : EndpointBase<BulkDeActivateUserRequestViewModel, BulkDeActivateUserResponseViewModel>
    {
        public BulkDeActivateUserEndPoint(EndpointBaseParameters<BulkDeActivateUserRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.BulkDeActivateUser })]
        public async Task<EndPointResponse<BulkDeActivateUserResponseViewModel>> BulkDeActivateUser(BulkDeActivateUserRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<BulkDeActivateUserOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<BulkDeActivateUserResponseViewModel>.Success(new BulkDeActivateUserResponseViewModel(), "Bulk Users DeActivated successfully.");
            else
                return EndPointResponse<BulkDeActivateUserResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
