using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.TaskDependencies;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.TaskDependencies.DeleteTaskDependency.Command
{
    public record DeleteTaskDependencyCommand(string TaskId) : IRequestBase<bool>;

    public class DeleteTaskDependencyCommandHandler
        : RequestHandlerBase<TaskDependency, DeleteTaskDependencyCommand, bool>
    {
        public DeleteTaskDependencyCommandHandler(RequestHandlerBaseParameters<TaskDependency> requestParameters)
            : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteTaskDependencyCommand request, CancellationToken cancellationToken)
        {
            var taskDependencies = await _repository
                .Get(s => s.SourceTaskId == request.TaskId)
                .ToListAsync(cancellationToken);

            if (taskDependencies == null || !taskDependencies.Any())
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            foreach (var dependency in taskDependencies)
            {
                _repository.Delete(dependency);
            }

             _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
