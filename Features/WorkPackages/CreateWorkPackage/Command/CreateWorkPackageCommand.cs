using EasyTask.Common.Requests;
using EasyTask.Models.WorkPackages;

namespace EasyTask.Features.WorkPackages.CreateWorkPackage.Command
{
    public record CreateWorkPackageCommand(string Name, DateTime StartDate, DateTime EndDate, string ProjectId):IRequestBase<string>;
    public class CreateWorkPackageCommandHandler : RequestHandlerBase<WorkPackage, CreateWorkPackageCommand, string>
    {
        public CreateWorkPackageCommandHandler(RequestHandlerBaseParameters<WorkPackage> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CreateWorkPackageCommand request, CancellationToken cancellationToken)
        {
            WorkPackage workPackage = new WorkPackage
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                ProjectId = request.ProjectId
            };

            _repository.Add(workPackage);
            _repository.SaveChanges();
            return RequestResult<string>.Success(workPackage.ID);
        }
    }
}
