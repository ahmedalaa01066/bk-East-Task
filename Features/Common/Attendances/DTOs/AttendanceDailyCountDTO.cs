using AutoMapper;
using EasyTask.Models.Attendances;

namespace EasyTask.Features.Common.Attendances.DTOs
{
    public class AttendanceDailyCountDTO
    {
        public DateOnly Date { get; set; }
        public int AttendanceCount { get; set; }
    }
    public class AttendanceDailyCountDTOProfile : Profile
    {
        public AttendanceDailyCountDTOProfile()
        {
            CreateMap<Attendance, AttendanceDailyCountDTO>();
        }
    }
}
