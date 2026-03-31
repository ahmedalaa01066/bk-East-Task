using EasyTask.Common.Endpoints;
using EasyTask.Features.PauseShifts.StartPause.Orchestrators;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PauseShifts.StartPause
{
    public class StartPauseEndpoint : EndpointBase<StartPauseRequestViewModel, StartPauseResponseViewModel>
    {
        public StartPauseEndpoint(EndpointBaseParameters<StartPauseRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.StartPause })]
        public async Task<EndPointResponse<StartPauseResponseViewModel>> StartPause(StartPauseRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            
            var result = await _mediator.Send(viewModel.MapOne<StartPauseOrchestrator>());
            var response = result.Data.MapOne<StartPauseResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<StartPauseResponseViewModel>.Success(response, "Pause started successfully");
            else
                return EndPointResponse<StartPauseResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
