using EasyTask.Models.Candidates;
using EasyTask.Models.Shifts;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.PlannedShifts
{
    [Table("PlannedShift", Schema = "PlannedShifts")]
    public class PlannedShift : BaseModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate? Candidate { get; set; }

        [ForeignKey("Shift")]
        public string ShiftId { get; set; }
        public Shift? Shift { get; set; }
    }
}
