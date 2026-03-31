using EasyTask.Common.Endpoints;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Users.DeactivateUser.Commands;
using EasyTask.Helpers;

namespace EasyTask.Features.Users.DeactivateUser
{
    public class DeactivateUserEndPoint : EndpointBase<DeactivateUserRequestViewModel, DeactivateUserResponseViewModel>
    {
        public DeactivateUserEndPoint(EndpointBaseParameters<DeactivateUserRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeactivateUser })]
        public async Task<EndPointResponse<DeactivateUserResponseViewModel>> DeactivateUser(DeactivateUserRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeactivateUserCommand>());
            if (result.IsSuccess)
                return EndPointResponse<DeactivateUserResponseViewModel>.Success(new DeactivateUserResponseViewModel(), "User Deactivated successfully.");
            else
                return EndPointResponse<DeactivateUserResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
