using EasyTask.Common.Endpoints;
using EasyTask.Features.Levels.DeleteLevel.Command;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Levels.DeleteLevel
{
    public class DeleteLevelEndPoint : EndpointBase<DeleteLevelRequestViewModel, DeleteLevelResponseViewModel>
    {
        public DeleteLevelEndPoint(EndpointBaseParameters<DeleteLevelRequestViewModel> parameters) : base(parameters) { }
        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteLevel })]
        public async Task<EndPointResponse<DeleteLevelResponseViewModel>> DeleteLevel(DeleteLevelRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteLevelCammand>());
            if (result.IsSuccess)
                return EndPointResponse<DeleteLevelResponseViewModel>.Success(new DeleteLevelResponseViewModel(), "Level Deleted Successfully");
            else
                return EndPointResponse<DeleteLevelResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
