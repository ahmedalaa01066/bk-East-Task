using EasyTask.Common.Requests;
using EasyTask.Features.Common.TaskDependencies.DTOs;
using EasyTask.Features.ProjectTasks.EditTast.Commands;
using EasyTask.Features.TaskDependencies.CreateTaskDependency.Commands;
using EasyTask.Features.TaskDependencies.DeleteTaskDependency.Command;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;

namespace EasyTask.Features.ProjectTasks.EditTast.Orchestrators
{
    public record EditTaskOrchestrators(string ID ,string Name, DateTime StartDate, DateTime EndDate, string ProjectId,
       string WorkPackageId, TaskPriority TaskPriority, List<CreateTaskDependencyDTO>? WorkPackageDependencyDTOs):IRequestBase<bool>;
    public class EditTastOrchestratorsHandler : RequestHandlerBase<ProjectTask, EditTaskOrchestrators, bool>
    {
        public EditTastOrchestratorsHandler(RequestHandlerBaseParameters<ProjectTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditTaskOrchestrators request, CancellationToken cancellationToken)
        {
            var task = await _mediator.Send(request.MapOne<EditTaskCommand>());
            if (!task.IsSuccess)
            {
                return RequestResult<bool>.Failure(task.ErrorCode);
            }
            var taskdependency = await _mediator.Send(new DeleteTaskDependencyCommand(request.ID));
            if (!taskdependency.IsSuccess)
            {
                return RequestResult<bool>.Failure(taskdependency.ErrorCode);
            }
            if (request.WorkPackageDependencyDTOs != null && request.WorkPackageDependencyDTOs.Any())
            {
                foreach (var dependencyDto in request.WorkPackageDependencyDTOs)
                {
                    var dependencyCommand = new CreateTaskDependencyCommand(
                        dependencyDto.DependencyType,
                        request.ID,
                        dependencyDto.DestinationtaskId
                    );

                    await _mediator.Send(dependencyCommand, cancellationToken);
                }
            }

            return RequestResult<bool>.Success(true);
        }
    }
}
