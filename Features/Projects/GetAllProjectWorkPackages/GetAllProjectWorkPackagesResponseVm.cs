using EasyTask.Models.Enums;

namespace EasyTask.Features.Projects.GetAllProjectWorkPackages;

public class GetAllProjectWorkPackagesResponseVm
{
    public List<GetAllProjectWorkPackagesItemVm> WorkPackages { get; set; } = new();
}

public class GetAllProjectWorkPackagesItemVm
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<GetAllProjectWorkPackageDependencyVm> OutgoingDependencies { get; set; } = new();
    public List<GetAllProjectWorkPackageDependencyVm> IncomingDependencies { get; set; } = new();
}

public class GetAllProjectWorkPackageDependencyVm
{
    public Dependencies DependencyType { get; set; }
    public string WorkPackageId { get; set; } = string.Empty;
}
