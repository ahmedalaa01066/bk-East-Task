using EasyTask.Models.Candidates;
using EasyTask.Models.Permissions;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.CandidatePermissions
{
    [Table("CandidatePermission", Schema = "CandidatePermissions")]
    public class CandidatePermission : BaseModel
    {
        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate? Candidate { get; set; }

        [ForeignKey("Permission")]
        public string PermissionId { get; set; }
        public Permission? Permission { get; set; }

        public TimeSpan NumOfHoursOfPermission { get; set; }
        public DateTime PermissionMonth { get; set; }
        public TimeSpan HoursLeftInMonth { get; set; }

    }
}
