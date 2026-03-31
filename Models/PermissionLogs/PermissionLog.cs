using EasyTask.Models.Candidates;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.PermissionLogs
{
    [Table("PermissionLog", Schema = "PermissionLogs")]
    public class PermissionLog : BaseModel
    {
        public DateTime LeaveDate { get; set; }
        public DateTime? ComeBackDate { get; set; }

        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
    }
}
