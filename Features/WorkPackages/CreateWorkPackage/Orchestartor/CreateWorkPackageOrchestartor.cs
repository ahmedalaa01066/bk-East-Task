using EasyTask.Common.Requests;
using EasyTask.Features.Common.WorkPackageDependencies.DTO;
using EasyTask.Features.WorkPackageDependencies.CreateWorkPackageDependency.Command;
using EasyTask.Features.WorkPackages.CreateWorkPackage.Command;
using EasyTask.Helpers;
using EasyTask.Models.WorkPackages;

namespace EasyTask.Features.WorkPackages.CreateWorkPackage.Orchestartor
{
    public record CreateWorkPackageOrchestartor(string Name, DateTime StartDate, DateTime EndDate, string ProjectId,
        List<CreateWorkPackageDependencyDTO>? WorkPackageDependencyDTOs):IRequestBase<bool>;
    public class CreateWorkPackageOrchestartorHandler : RequestHandlerBase<WorkPackage, CreateWorkPackageOrchestartor, bool>
    {
        public CreateWorkPackageOrchestartorHandler(RequestHandlerBaseParameters<WorkPackage> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateWorkPackageOrchestartor request, CancellationToken cancellationToken)
        {
            var workpackage = await _mediator.Send(request.MapOne<CreateWorkPackageCommand>());
            if (!workpackage.IsSuccess) {
                return RequestResult<bool>.Failure(workpackage.ErrorCode);
            }
            if (request.WorkPackageDependencyDTOs != null && request.WorkPackageDependencyDTOs.Any())
            {
                foreach (var dependencyDto in request.WorkPackageDependencyDTOs)
                {
                    var dependencyCommand = new CreateWorkPackageDependencyCommand(
                        dependencyDto.DependencyType,
                        workpackage.Data,
                        dependencyDto.DestinationWorkPackageId
                    );

                    await _mediator.Send(dependencyCommand, cancellationToken);
                }
            }

            return RequestResult<bool>.Success(true);
        }
    }
}
