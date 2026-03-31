using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Helpers;
using EasyTask.Features.Users.AdminLogin.Commands;

namespace EasyTask.Features.Users.AdminLogin
{
    public class AdminLoginEndPoint : EndpointBase<AdminLoginRequestViewModel, AdminLoginResponseViewModel>
    {
        public AdminLoginEndPoint(EndpointBaseParameters<AdminLoginRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        public async Task<EndPointResponse<AdminLoginResponseViewModel>> Post(AdminLoginRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AdminLoginCommand>());
            if (result.IsSuccess)
            {
                return EndPointResponse<AdminLoginResponseViewModel>.Success(result.Data.MapOne<AdminLoginResponseViewModel>(), "You Logined successfully");
            }
            return EndPointResponse<AdminLoginResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
