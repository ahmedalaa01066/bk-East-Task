using EasyTask.Common.Interfaces;
using EasyTask.Models.Projects;
using EasyTask.Models.ProjectTasks;
using EasyTask.Models.WorkPackageDependencies;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.WorkPackages
{
    [Table("WorkPackage", Schema = "WorkPackages")]
    public class WorkPackage : BaseModel, ISelectableListItem
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("Project")]
        public string ProjectId { get; set; }
        public Project? Project { get; set; }
        [InverseProperty("SourceWorkPackage")]
        public ICollection<WorkPackageDependency> OutgoingDependencies { get; set; } = new List<WorkPackageDependency>();

        [InverseProperty("DestinationWorkPackage")]
        public ICollection<WorkPackageDependency> IncomingDependencies { get; set; } = new List<WorkPackageDependency>();
        public ICollection<ProjectTask>? ProjectTasks { get; set; }
    }
}
