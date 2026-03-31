using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Helpers;
using EasyTask.Features.Users.Login.Commands;
using EasyTask.Features.Users.Login.Orchestrator;

namespace EasyTask.Features.Users.Login
{
    public class LoginEndPoint : EndpointBase<LoginRequestViewModel, LoginResponseViewModel>
    {
        public LoginEndPoint(EndpointBaseParameters<LoginRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        public async Task<EndPointResponse<LoginResponseViewModel>> Post(LoginRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<LoginOrchestrator>());
            if (result.IsSuccess)
            {
                return EndPointResponse<LoginResponseViewModel>.Success(result.Data.MapOne<LoginResponseViewModel>(), "You Logined successfully");
            }
            return EndPointResponse<LoginResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
