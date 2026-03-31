using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.ProjectTasks;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Tasks.DeleteTask.Commands
{
    public record DeleteTaskCommand(string ID):IRequestBase<bool>;
    public class DeleteTaskCommandHandler : RequestHandlerBase<ProjectTask, DeleteTaskCommand, bool>
    {
        public DeleteTaskCommandHandler(RequestHandlerBaseParameters<ProjectTask> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository
                  .Get(s => s.ID == request.ID)
                  .FirstOrDefaultAsync();

            if (task == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            _repository.Delete(task);
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
