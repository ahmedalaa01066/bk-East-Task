using EasyTask.Common.Requests;
using EasyTask.Features.Common.TaskDependencies.DTOs;
using EasyTask.Features.ProjectTasks.CreateTask.Commands;
using EasyTask.Features.TaskDependencies.CreateTaskDependency.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;

namespace EasyTask.Features.ProjectTasks.CreateTask.Orchestrators
{
    public record CreateTaskOrchestrator(string Name, DateTime StartDate, DateTime EndDate, string ProjectId,
       string WorkPackageId, TaskPriority TaskPriority, List<CreateTaskDependencyDTO>? WorkPackageDependencyDTOs) : IRequestBase<bool>;
    public class CreateTaskOrchestratorHandler : RequestHandlerBase<ProjectTask, CreateTaskOrchestrator, bool>
    {
        public CreateTaskOrchestratorHandler(RequestHandlerBaseParameters<ProjectTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateTaskOrchestrator request, CancellationToken cancellationToken)
        {
            var task = await _mediator.Send(request.MapOne<CreateTaskCommand>());
            if (!task.IsSuccess)
            {
                return RequestResult<bool>.Failure(task.ErrorCode);
            }
            if (request.WorkPackageDependencyDTOs != null && request.WorkPackageDependencyDTOs.Any())
            {
                foreach (var dependencyDto in request.WorkPackageDependencyDTOs)
                {
                    var dependencyCommand = new CreateTaskDependencyCommand(
                        dependencyDto.DependencyType,
                        task.Data,
                        dependencyDto.DestinationtaskId
                    );

                    await _mediator.Send(dependencyCommand, cancellationToken);
                }
            }

            return RequestResult<bool>.Success(true);
        }
    }
}
