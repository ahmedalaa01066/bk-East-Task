using EasyTask.Common.Endpoints;
using EasyTask.Features.Positions.CreatePosition.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Positions.CreatePosition
{
    public class CreatePositionEndPoint : EndpointBase<CreatePositionRequestViewModel, CreatePositionResponseViewModel>
    {
        public CreatePositionEndPoint(EndpointBaseParameters<CreatePositionRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreatePosition })]
        public async Task<EndPointResponse<CreatePositionResponseViewModel>> CreatePosition(CreatePositionRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreatePositionCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<CreatePositionResponseViewModel>.Success(new CreatePositionResponseViewModel(), "Position Added successfully.");
            }
            return EndPointResponse<CreatePositionResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
