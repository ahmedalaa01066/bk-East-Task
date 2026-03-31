using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;

namespace EasyTask.Features.ProjectTasks.EditTaskPriority.Commands
{
    public record EditTaskPriorityCommand(string ID, TaskPriority TaskPriority) : IRequestBase<bool>;
    public class EditTaskPriorityCommandHandler : RequestHandlerBase<ProjectTask, EditTaskPriorityCommand, bool>
    {
        public EditTaskPriorityCommandHandler(RequestHandlerBaseParameters<ProjectTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditTaskPriorityCommand request, CancellationToken cancellationToken)
        {
            var projectTask = new ProjectTask
            {
                ID = request.ID,
                TaskPriority = request.TaskPriority,
            };

            _repository.SaveIncluded(projectTask, nameof(projectTask.TaskPriority));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
