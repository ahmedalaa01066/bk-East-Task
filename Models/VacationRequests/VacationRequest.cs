using EasyTask.Models.Candidates;
using EasyTask.Models.Vacations;
using EasyTask.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.VacationRequests
{
    [Table("VacationRequest", Schema = "VacationRequests")]
    public class VacationRequest : BaseModel
    {
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public RequestStatus VacationRequestStatus { get; set; }
        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        [ForeignKey("Vacation")]
        public string VacationId { get; set; }
        public Vacation Vacation { get; set; }
    }
}
