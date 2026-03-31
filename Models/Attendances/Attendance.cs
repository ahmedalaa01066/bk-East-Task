using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using EasyTask.Models.PauseShifts;
using EasyTask.Models.Shifts;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Attendances
{
    [Table("Attendance", Schema = "Attendances")]
    public class Attendance : BaseModel
    {
        public DateTime ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public AttendanceActivation AttendanceActivation { get; set; }
        public TimeSpan? TotalPauseDuration { get; set; }

        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate? Candidate { get; set; }

        [ForeignKey("Shift")]
        public string ShiftId { get; set; }
        public Shift? Shift { get; set; }

        public ICollection<PauseShift> PauseShifts { get; set; }    

    }
}
