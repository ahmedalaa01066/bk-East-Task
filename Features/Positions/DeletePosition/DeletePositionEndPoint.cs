using EasyTask.Common.Endpoints;
using EasyTask.Features.Positions.DeletePosition.Command;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Positions.DeletePosition
{
    public class DeletePositionEndPoint : EndpointBase<DeletePositionRequestViewModel, DeletePositionResponseViewModel>
    {
        public DeletePositionEndPoint(EndpointBaseParameters<DeletePositionRequestViewModel> parameters) : base(parameters) { }
        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeletePosition })]
        public async Task<EndPointResponse<DeletePositionResponseViewModel>> DeletePosition(DeletePositionRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeletePositionCammand>());
            if (result.IsSuccess)
                return EndPointResponse<DeletePositionResponseViewModel>.Success(new DeletePositionResponseViewModel(), "Position Deleted Successfully");
            else
                return EndPointResponse<DeletePositionResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
