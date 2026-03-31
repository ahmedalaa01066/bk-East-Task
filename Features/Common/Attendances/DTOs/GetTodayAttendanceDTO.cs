using AutoMapper;
using EasyTask.Models.Attendances;

namespace EasyTask.Features.Common.Attendances.DTOs
{
    public class GetTodayAttendanceDTO
    {
        public int Attendance { get; set; }
        public int Annual { get; set; }
        public int WorkFromHome { get; set; }
    }
    public class GetTodayAttendanceDTOProfile : Profile
    {
        public GetTodayAttendanceDTOProfile()
        {
            CreateMap<Attendance, GetTodayAttendanceDTO>();
        }
    }
}
