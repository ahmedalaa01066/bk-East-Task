using EasyTask.Common.Endpoints;
using EasyTask.Features.ProjectTasks.CreateTask.Orchestrators;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectTasks.CreateTask
{
    public class CreateTaskEndPoint : EndpointBase<CreateTaskRequestViewModel, CreateTaskResponseViewModel>
    {
        public CreateTaskEndPoint(EndpointBaseParameters<CreateTaskRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateTask })]
        public async Task<EndPointResponse<CreateTaskResponseViewModel>> CreateTask(CreateTaskRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateTaskOrchestrator>());

            if (result.IsSuccess)
            {
                return EndPointResponse<CreateTaskResponseViewModel>.Success(new CreateTaskResponseViewModel(), "Task Added successfully.");
            }
            return EndPointResponse<CreateTaskResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
