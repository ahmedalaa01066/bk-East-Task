using EasyTask.Common.Endpoints;
using EasyTask.Features.Managements.EditManagement.Orchestrator;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Managements.EditManagement
{
    public class EditManagementEndPoint : EndpointBase<EditManagementRequestViewModel, EditManagementResponseViewModel>
    {
        public EditManagementEndPoint(EndpointBaseParameters<EditManagementRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditManagement })]
        public async Task<EndPointResponse<EditManagementResponseViewModel>> EditManagement(EditManagementRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditManagementOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<EditManagementResponseViewModel>.Success(new EditManagementResponseViewModel(), "Management Updated Successfully");
            else
                return EndPointResponse<EditManagementResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
