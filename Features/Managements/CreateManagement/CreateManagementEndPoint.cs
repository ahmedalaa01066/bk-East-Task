using EasyTask.Common.Endpoints;
using EasyTask.Features.Managements.CreateManagement.Orchestrator;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Managements.CreateManagement
{
    public class CreateManagementEndPoint : EndpointBase<CreateManagementRequestViewModel, CreateManagementResponseViewModel>
    {
        public CreateManagementEndPoint(EndpointBaseParameters<CreateManagementRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateManagement })]
        public async Task<EndPointResponse<CreateManagementResponseViewModel>> AddManagement(CreateManagementRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateManagementOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<CreateManagementResponseViewModel>.Success(new CreateManagementResponseViewModel(), "Management Added Successfully");
            else
                return EndPointResponse<CreateManagementResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
