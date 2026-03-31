using EasyTask.Common.Endpoints;
using EasyTask.Features.Managements.DeleteManagement.Orchestrator;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Managements.DeleteManagement
{
    public class DeleteManagementEndPoint : EndpointBase<DeleteManagementRequestViewModel, DeleteManagementResponseViewModel>
    {
        public DeleteManagementEndPoint(EndpointBaseParameters<DeleteManagementRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteManagement })]
        public async Task<EndPointResponse<DeleteManagementResponseViewModel>> DeleteManagement(DeleteManagementRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteManagementOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<DeleteManagementResponseViewModel>.Success(new DeleteManagementResponseViewModel(), "Management Deleted Successfully");
            else
                return EndPointResponse<DeleteManagementResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
