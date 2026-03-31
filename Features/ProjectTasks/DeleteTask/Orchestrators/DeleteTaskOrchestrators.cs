using EasyTask.Common.Requests;
using EasyTask.Features.Common.TaskDependencies.DTOs;
using EasyTask.Features.TaskDependencies.DeleteTaskDependency.Command;
using EasyTask.Features.Tasks.DeleteTask.Commands;
using EasyTask.Helpers;
using EasyTask.Models.ProjectTasks;

namespace EasyTask.Features.ProjectTasks.DeleteTast.Orchestrators
{
    public record DeleteTaskOrchestrators(string ID ,string Name, DateTime StartDate, DateTime EndDate, string ProjectId,
       string WorkPackageId, List<CreateTaskDependencyDTO>? WorkPackageDependencyDTOs):IRequestBase<bool>;
    public class DeleteTastOrchestratorsHandler : RequestHandlerBase<ProjectTask, DeleteTaskOrchestrators, bool>
    {
        public DeleteTastOrchestratorsHandler(RequestHandlerBaseParameters<ProjectTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteTaskOrchestrators request, CancellationToken cancellationToken)
        {
            var task = await _mediator.Send(request.MapOne<DeleteTaskCommand>());
            if (!task.IsSuccess)
            {
                return RequestResult<bool>.Failure(task.ErrorCode);
            }
            var taskdependency = await _mediator.Send(new DeleteTaskDependencyCommand(request.ID));
            if (!taskdependency.IsSuccess)
            {
                return RequestResult<bool>.Failure(taskdependency.ErrorCode);
            }
            return RequestResult<bool>.Success(true);
        }
    }
}
