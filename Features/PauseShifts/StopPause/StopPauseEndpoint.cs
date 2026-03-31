using EasyTask.Common.Endpoints;
using EasyTask.Features.PauseShifts.StopPause.Orchestrators;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PauseShifts.StopPause
{
    public class StopPauseEndpoint : EndpointBase<StopPauseRequestViewModel, StopPauseResponseViewModel>
    {
        public StopPauseEndpoint(EndpointBaseParameters<StopPauseRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.StopPause })]
        public async Task<EndPointResponse<StopPauseResponseViewModel>> StopPause(StopPauseRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            
            var result = await _mediator.Send(viewModel.MapOne<StopPauseOrchestrator>());

            if (result.IsSuccess)
                return EndPointResponse<StopPauseResponseViewModel>
                    .Success(new StopPauseResponseViewModel(), "Pause Stopped successfully");
            else
                return EndPointResponse<StopPauseResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
