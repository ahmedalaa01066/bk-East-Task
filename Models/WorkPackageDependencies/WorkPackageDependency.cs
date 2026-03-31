using EasyTask.Models.Enums;
using EasyTask.Models.WorkPackages;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.WorkPackageDependencies
{
    [Table("WorkPackageDependency", Schema = "WorkPackageDependencies")]
    public class WorkPackageDependency : BaseModel
    {
        public Dependencies DependencyType { get; set; }

        [ForeignKey("SourceWorkPackage")]
        public string SourceWorkPackageId { get; set; } = string.Empty;

        [InverseProperty(nameof(WorkPackage.OutgoingDependencies))]
        public WorkPackage? SourceWorkPackage { get; set; }

        [ForeignKey("DestinationWorkPackage")]
        public string DestinationWorkPackageId { get; set; } = string.Empty;

        [InverseProperty(nameof(WorkPackage.IncomingDependencies))]
        public WorkPackage? DestinationWorkPackage { get; set; }
    }
}
