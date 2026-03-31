using EasyTask.Common.Endpoints;
using EasyTask.Features.ProjectTasks.EditTast.Orchestrators;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectTasks.EditTast
{
    public class EditTaskEndpoint : EndpointBase<EditTaskRequestViewModel, EditTaskResponseViewModel>
    {
        public EditTaskEndpoint(EndpointBaseParameters<EditTaskRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditTask })]
        public async Task<EndPointResponse<EditTaskResponseViewModel>> EditTask(EditTaskRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditTaskOrchestrators>());

            if (result.IsSuccess)
            {
                return EndPointResponse<EditTaskResponseViewModel>.Success(new EditTaskResponseViewModel(), "Task Edited successfully.");
            }
            return EndPointResponse<EditTaskResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
