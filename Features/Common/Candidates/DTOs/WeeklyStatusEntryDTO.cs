using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public class WeeklyStatusEntryDTO
    {
        public string DayName { get; set; }
        public DateOnly Date { get; set; }
        public DayStatus Status { get; set; }
    }
}
