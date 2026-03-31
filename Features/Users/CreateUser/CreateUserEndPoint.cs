using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Common.Users.CreateUser.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Users.CreateUser
{
    public class CreateUserEndPoint : EndpointBase<CreateUserRequestViewModel, CreateUserResponseViewModel>
    {
        public CreateUserEndPoint(EndpointBaseParameters<CreateUserRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateUser })]
        public async Task<EndPointResponse<CreateUserResponseViewModel>> Post(CreateUserRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateUserCommand>());
            if (result.IsSuccess)
            {
                return EndPointResponse<CreateUserResponseViewModel>.Success(new CreateUserResponseViewModel(), "User Added successfully.");
            }
            return EndPointResponse<CreateUserResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
