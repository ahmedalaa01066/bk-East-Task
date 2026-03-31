using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.TaskDependencies;

namespace EasyTask.Features.TaskDependencies.CreateTaskDependency.Commands
{
    public record CreateTaskDependencyCommand(Dependencies DependencyType, string SourceTaskId,
        string DestinationTaskId) : IRequestBase<bool>;
    public class CreateTaskDependencyCommandHandler : RequestHandlerBase<TaskDependency, CreateTaskDependencyCommand, bool>
    {
        public CreateTaskDependencyCommandHandler(RequestHandlerBaseParameters<TaskDependency> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateTaskDependencyCommand request, CancellationToken cancellationToken)
        {
            TaskDependency taskDependency = new TaskDependency
            {
                SourceTaskId = request.SourceTaskId,
                DestinationTaskId = request.DestinationTaskId,
                DependencyType = request.DependencyType,
            };

            _repository.Add(taskDependency);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
