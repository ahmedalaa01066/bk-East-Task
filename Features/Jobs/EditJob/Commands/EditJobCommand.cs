using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Jobs;

namespace EasyTask.Features.Jobs.EditJob.Commands
{
    public record EditJobCommand(
        string ID,
        string? Name,
        string? Description,
        string? ManagementId
    ) : IRequestBase<bool>;
    public class EditJobCommandHandler : RequestHandlerBase<Job, EditJobCommand, bool>
    {
        public EditJobCommandHandler(RequestHandlerBaseParameters<Job> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditJobCommand request, CancellationToken cancellationToken)
        {
            var Job = await _repository.GetByIDAsync(request.ID);
            if (Job == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            Job.Name = request.Name ?? Job.Name;
            Job.Description = request.Description ?? Job.Description;
            Job.ManagementId = request.ManagementId ?? Job.ManagementId;

            _repository.SaveIncluded(Job, nameof(Job.Name), nameof(Job.Description),nameof(Job.ManagementId));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
