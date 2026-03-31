using EasyTask.Models.Candidates;
using EasyTask.Models.ProjectTasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.CandidateTasks
{
    [Table("CandidateTask", Schema = "CandidateTasks")]
    public class CandidateTask : BaseModel
    {
        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        [ForeignKey("ProjectTask")]
        public string ProjectTaskId { get; set; }
        public ProjectTask ProjectTask { get; set; }
    }
}
