using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;

namespace EasyTask.Features.ProjectTasks.CreateTask.Commands
{
    public record CreateTaskCommand
        (string Name, DateTime StartDate, DateTime EndDate, string ProjectId, string WorkPackageId,
        TaskPriority TaskPriority) : IRequestBase<string>;
    public class CreateTaskCommandHandler : RequestHandlerBase<ProjectTask, CreateTaskCommand, string>
    {
        public CreateTaskCommandHandler(RequestHandlerBaseParameters<ProjectTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            ProjectTask projectTask = new ProjectTask
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                ProjectId = request.ProjectId,
                WorkPackageId = request.WorkPackageId,
                TaskPriority = request.TaskPriority
            };

            _repository.Add(projectTask);
            _repository.SaveChanges();
            return RequestResult<string>.Success(projectTask.ID);
        }
    }
}
