using EasyTask.Common.Endpoints;
using EasyTask.Features.Managements.DeactiveManagement.Orchestrator;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Managements.DeactiveManagement
{
    public class DeactiveManagementEndPoint : EndpointBase<DeactiveManagementRequestViewModel, DeactiveManagementResponseViewModel>
    {
        public DeactiveManagementEndPoint(EndpointBaseParameters<DeactiveManagementRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeactiveManagement })]
        public async Task<EndPointResponse<DeactiveManagementResponseViewModel>> Deactive(DeactiveManagementRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeactiveManagementOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<DeactiveManagementResponseViewModel>.Success(new DeactiveManagementResponseViewModel(), "Management Deactivated Successfully");
            else
                return EndPointResponse<DeactiveManagementResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
