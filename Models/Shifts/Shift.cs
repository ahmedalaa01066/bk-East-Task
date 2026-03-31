using EasyTask.Models.Attendances;
using EasyTask.Models.PlannedShifts;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Shifts
{
    [Table("Shift", Schema = "Shifts")]
    public class Shift : BaseModel
    {
        public string Name { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public bool PauseOption { get; set; }
        public TimeSpan? MaxPauseDuration { get; set; }
        public TimeSpan? MarginBefore { get; set; }
        public TimeSpan? MarginAfter { get; set; }
        public ICollection<PlannedShift>? PlannedShifts { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
    }
}
