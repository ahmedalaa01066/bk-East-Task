using EasyTask.Common.Requests;
using EasyTask.Models.WorkPackages;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Projects.GetAllProjectWorkPackages.Queries;

public record GetAllProjectWorkPackagesQuery(string ProjectId) : IRequestBase<GetAllProjectWorkPackagesResponseVm>;

public class GetAllProjectWorkPackagesQueryHandler(RequestHandlerBaseParameters<WorkPackage> requestParameters)
    : RequestHandlerBase<WorkPackage,
        GetAllProjectWorkPackagesQuery, GetAllProjectWorkPackagesResponseVm>(
        requestParameters)
{
    public override async Task<RequestResult<GetAllProjectWorkPackagesResponseVm>> Handle(GetAllProjectWorkPackagesQuery request, CancellationToken cancellationToken)
    {
        var workPackages = await _repository.Get(wp => wp.ProjectId == request.ProjectId)
            .Select(wp => new GetAllProjectWorkPackagesItemVm
            {
                Id = wp.ID,
                Name = wp.Name,
                StartDate = wp.StartDate,
                EndDate = wp.EndDate,
                OutgoingDependencies = wp.OutgoingDependencies
                    .Select(d => new GetAllProjectWorkPackageDependencyVm
                    {
                        DependencyType = d.DependencyType,
                        WorkPackageId = d.DestinationWorkPackageId
                    })
                    .ToList(),
                IncomingDependencies = wp.IncomingDependencies
                    .Select(d => new GetAllProjectWorkPackageDependencyVm
                    {
                        DependencyType = d.DependencyType,
                        WorkPackageId = d.SourceWorkPackageId
                    })
                    .ToList()
            })
            .ToListAsync(cancellationToken);

        return RequestResult<GetAllProjectWorkPackagesResponseVm>.Success(new GetAllProjectWorkPackagesResponseVm
        {
            WorkPackages = workPackages
        });
    }
}
