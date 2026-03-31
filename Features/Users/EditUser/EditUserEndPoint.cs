using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Users.EditUser.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Users.EditClient
{
    public class EditUserEndPoint : EndpointBase<EditUserRequestViewModel, EditUserResponseViewModel>
    {
        public EditUserEndPoint(EndpointBaseParameters<EditUserRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditUser })]
        public async Task<EndPointResponse<EditUserResponseViewModel>> Put(EditUserRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<EditUserCommand>());

            if (result.IsSuccess)
                return EndPointResponse<EditUserResponseViewModel>.Success(new EditUserResponseViewModel(), "User Updated successfully");
            else
                return EndPointResponse<EditUserResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
