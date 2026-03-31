using EasyTask.Common.Endpoints;
using EasyTask.Features.Users.ActivateUser.Commands;
using EasyTask.Features.Users.ActivateUser;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Users.BulkActivateUser.Orchestrator;
using EasyTask.Helpers;

namespace EasyTask.Features.Users.BulkActivateUser
{
    public class BulkActivateUserEndPoint : EndpointBase<BulkActivateUserRequestViewModel, BulkActivateUserResponseViewModel>
    {
        public BulkActivateUserEndPoint(EndpointBaseParameters<BulkActivateUserRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.BulkActivateUser })]
        public async Task<EndPointResponse<BulkActivateUserResponseViewModel>> BulkActivateUser(BulkActivateUserRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<BulkActivateUserOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<BulkActivateUserResponseViewModel>.Success(new BulkActivateUserResponseViewModel(), "Bulk Users Activated successfully.");
            else
                return EndPointResponse<BulkActivateUserResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
