using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.WorkPackageDependencies;

namespace EasyTask.Features.WorkPackageDependencies.CreateWorkPackageDependency.Command
{
    public record CreateWorkPackageDependencyCommand(Dependencies DependencyType, string SourceWorkPackageId,
        string DestinationWorkPackageId):IRequestBase<bool>;
    public class CreateWorkPackageDependencyCommandHandler : RequestHandlerBase<WorkPackageDependency, CreateWorkPackageDependencyCommand, bool>
    {
        public CreateWorkPackageDependencyCommandHandler(RequestHandlerBaseParameters<WorkPackageDependency> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateWorkPackageDependencyCommand request, CancellationToken cancellationToken)
        {
            WorkPackageDependency workPackage = new WorkPackageDependency
            {
                SourceWorkPackageId=request.SourceWorkPackageId,
                DestinationWorkPackageId=request.DestinationWorkPackageId,
                DependencyType=request.DependencyType,
            };

            _repository.Add(workPackage);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
