using EasyTask.Models.ExternalMembers;
using EasyTask.Models.ProjectTasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.ExternalMemberTasks
{
    [Table("ExternalMemberTask", Schema = "ExternalMemberTasks")]
    public class ExternalMemberTask : BaseModel
    {
        [ForeignKey("ExternalMember")]
        public string ExternalMemberId { get; set; }
        public ExternalMember ExternalMember { get; set; }
        [ForeignKey("ProjectTask")]
        public string ProjectTaskId { get; set; }
        public ProjectTask ProjectTask { get; set; }
    }
}
