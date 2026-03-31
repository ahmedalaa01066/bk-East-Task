using EasyTask.Common.Endpoints;
using EasyTask.Features.Managements.ActiveManagement.Commands;
using EasyTask.Features.Managements.ActiveManagement.Orchestrator;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Managements.ActiveManagement
{
    public class ActiveManagementEndPoint : EndpointBase<ActiveManagementRequestViewModel, ActiveManagementResponseViewModel>
    {
        public ActiveManagementEndPoint(EndpointBaseParameters<ActiveManagementRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ActiveManagement })]
        public async Task<EndPointResponse<ActiveManagementResponseViewModel>> Active(ActiveManagementRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<ActiveManagementOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<ActiveManagementResponseViewModel>.Success(new ActiveManagementResponseViewModel(), "Management Activated Successfully");
            else
                return EndPointResponse<ActiveManagementResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
