using EasyTask.Models.Attendances;
using EasyTask.Models.Candidates;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.PauseShifts
{
    [Table("PauseShift", Schema = "PauseShifts")]
    public class PauseShift : BaseModel
    {
        public TimeSpan FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
        [ForeignKey("Attendance")]
        public string AttendanceId { get; set; }
        public Attendance? Attendance { get; set; }

    }
}
