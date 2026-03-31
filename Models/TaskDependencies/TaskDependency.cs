using EasyTask.Models.Enums;
using EasyTask.Models.ProjectTasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.TaskDependencies
{
    [Table("TaskDependency", Schema = "TaskDependencies")]
    public class TaskDependency : BaseModel
    {
        public Dependencies DependencyType { get; set; }

        [ForeignKey("SourceTask")]
        public string SourceTaskId { get; set; }

        [InverseProperty(nameof(ProjectTask.OutgoingDependencies))]
        public ProjectTask? SourceTask { get; set; }

        [ForeignKey("DestinationTask")]
        public string DestinationTaskId { get; set; }

        [InverseProperty(nameof(ProjectTask.IncomingDependencies))]
        public ProjectTask? DestinationTask { get; set; }
    }
}
