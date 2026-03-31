using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Jobs;

namespace EasyTask.Features.Jobs.CreateJob.Command
{
    public record CreateJobCommand(string Name, string Description, string ManagementId) : IRequestBase<bool>;
    public class CreateJobCommandHandler : RequestHandlerBase<Job, CreateJobCommand, bool>
    {
        public CreateJobCommandHandler(RequestHandlerBaseParameters<Job> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            string jobCode = GenerateGenericCode.Generate("J-");
            Job job = new Job
            {
                Name = request.Name,
                Description = request.Description,
                ManagementId = request.ManagementId,
                JobCode = jobCode
            };
            _repository.Add(job);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
