using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using EasyTask.Models.Permissions;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.PermissionRequests
{
    [Table("PermissionRequest", Schema = "PermissionRequests")]
    public class PermissionRequest : BaseModel
    {
        public DateOnly Date { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public RequestStatus PermissionRequestStatus { get; set; } = RequestStatus.Pending;
        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        [ForeignKey("Permission")]
        public string PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
