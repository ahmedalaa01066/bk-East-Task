using EasyTask.Common.Endpoints;
using EasyTask.Features.ProjectTasks.EditTaskPriority.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.ProjectTasks.EditTaskPriority
{
    public class EditTaskPriorityEndPoint : EndpointBase<EditTaskPriorityRequestViewModel, EditTaskPriorityResponseViewModel>
    {
        public EditTaskPriorityEndPoint(EndpointBaseParameters<EditTaskPriorityRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditTaskPriority })]
        public async Task<EndPointResponse<EditTaskPriorityResponseViewModel>> EditTaskPriority(EditTaskPriorityRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<EditTaskPriorityCommand>());

            if (result.IsSuccess)
                return EndPointResponse<EditTaskPriorityResponseViewModel>.Success(new EditTaskPriorityResponseViewModel(), "Priority Updated successfully");
            else
                return EndPointResponse<EditTaskPriorityResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
