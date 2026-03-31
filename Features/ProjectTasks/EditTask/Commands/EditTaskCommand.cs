using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;

namespace EasyTask.Features.ProjectTasks.EditTast.Commands
{
    public record EditTaskCommand(string ID,string Name, DateTime StartDate, DateTime EndDate,
       string WorkPackageId, TaskPriority TaskPriority) :IRequestBase<bool>;
    public class EditTastCommandHandler : RequestHandlerBase<ProjectTask, EditTaskCommand, bool>
    {
        public EditTastCommandHandler(RequestHandlerBaseParameters<ProjectTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditTaskCommand request, CancellationToken cancellationToken)
        {

            var task = new ProjectTask
            {
                ID = request.ID,
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                WorkPackageId = request.WorkPackageId,
                TaskPriority=request.TaskPriority,
            };

            _repository.SaveIncluded(task, nameof(task.Name),nameof(task.StartDate), nameof(task.EndDate), 
                nameof(task.WorkPackageId),nameof(request.TaskPriority));

            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
