using EasyTask.Common.Interfaces;
using EasyTask.Models.CandidateTasks;
using EasyTask.Models.Enums;
using EasyTask.Models.ExternalMemberTasks;
using EasyTask.Models.TaskDependencies;
using EasyTask.Models.WorkPackages;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.ProjectTasks
{
    [Table("ProjectTask", Schema = "ProjectTask")]
    public class ProjectTask : BaseModel, ISelectableListItem
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProjectId { get; set; }
        [ForeignKey("WorkPackage")]
        public string WorkPackageId { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public WorkPackage? WorkPackage { get; set; }
        [InverseProperty("SourceTask")]
        public ICollection<TaskDependency> OutgoingDependencies { get; set; } = new List<TaskDependency>();

        [InverseProperty("DestinationTask")]
        public ICollection<TaskDependency> IncomingDependencies { get; set; } = new List<TaskDependency>();
        public ICollection<CandidateTask>? CandidateTasks { get; set; }
        public ICollection<ExternalMemberTask>? ExternalMemberTasks { get; set; }
    }
}
