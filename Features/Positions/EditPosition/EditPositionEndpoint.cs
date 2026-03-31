using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Positions.EditPositions.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Middlewares;

namespace EasyTask.Features.Positions.EditPositions
{
    public class EditPositionEndpoint : EndpointBase<EditPositionRequestViewModel, EditPositionResponseViewModel>
    {
        public EditPositionEndpoint(EndpointBaseParameters<EditPositionRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditPosition })]
        public async Task<EndPointResponse<EditPositionResponseViewModel>> EditPosition(EditPositionRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditPositionCommand>());
            if (result.IsSuccess)
                return EndPointResponse<EditPositionResponseViewModel>.Success(new EditPositionResponseViewModel(), "Position Updated Successfully");
            else
                return EndPointResponse<EditPositionResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
