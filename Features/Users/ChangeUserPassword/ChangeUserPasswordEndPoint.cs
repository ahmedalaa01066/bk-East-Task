using EasyTask.Common.Endpoints;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Common.Users.ChangeUserPassword.Commands;
using EasyTask.Helpers;

namespace EasyTask.Features.Users.ChangeUserPassword
{
    public class ChangeUserPasswordEndPoint : EndpointBase<ChangeUserPasswordRequestViewModel, ChangeUserPasswordResponseViewModel>
    {
        public ChangeUserPasswordEndPoint(EndpointBaseParameters<ChangeUserPasswordRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ChangeUserPassword })]
        public async Task<EndPointResponse<ChangeUserPasswordResponseViewModel>> ChangeUserPassword(ChangeUserPasswordRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<ChangeUserPasswordCommand>());
            if (result.IsSuccess)
                return EndPointResponse<ChangeUserPasswordResponseViewModel>.Success(new ChangeUserPasswordResponseViewModel(), "PassWord changed successfully.");
            else
                return EndPointResponse<ChangeUserPasswordResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
