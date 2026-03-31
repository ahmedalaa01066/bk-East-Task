using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Jobs;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Jobs.DeleteJob.Commands
{
    public record DeleteJobCommand(string ID):IRequestBase<bool>;
    public class DeleteJobCommandHandler : RequestHandlerBase<Job, DeleteJobCommand, bool>
    {
        public DeleteJobCommandHandler(RequestHandlerBaseParameters<Job> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var Job = await _repository
                  .Get(s => s.ID == request.ID)
                  .Include(s => s.Candidates) 
                  .FirstOrDefaultAsync();

            if (Job == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            if (Job.Candidates != null && Job.Candidates.Any())
                return RequestResult<bool>.Failure(ErrorCode.CannotDelete); 

            _repository.Delete(Job);
             _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
