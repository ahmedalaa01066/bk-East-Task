using EasyTask.Common.Endpoints;
using EasyTask.Features.ProjectTasks.DeleteTast.Orchestrators;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Tasks.DeleteTask
{
    public class DeleteTaskEndpoint : EndpointBase<DeleteTaskRequestViewModel, DeleteTaskResponseViewModel>
    {
        public DeleteTaskEndpoint(EndpointBaseParameters<DeleteTaskRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteTask })]
        public async Task<EndPointResponse<DeleteTaskResponseViewModel>> Delete(DeleteTaskRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteTaskOrchestrators>());
            if (result.IsSuccess)
                return EndPointResponse<DeleteTaskResponseViewModel>.Success(new DeleteTaskResponseViewModel(), "Task Deleted Successfully");
            else
                return EndPointResponse<DeleteTaskResponseViewModel>.Failure(result.ErrorCode);
        }

    }
}
