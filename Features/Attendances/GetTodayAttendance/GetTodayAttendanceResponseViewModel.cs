using AutoMapper;
using EasyTask.Features.Common.Attendances.DTOs;

namespace EasyTask.Features.Attendances.GetTodayAttendance
{
    public record GetTodayAttendanceResponseViewModel
    (int Attendance, int Annual, int WorkFromHome);
    public class GetTodayAttendanceResponseProfile : Profile
    {
        public GetTodayAttendanceResponseProfile()
        {
            CreateMap<GetTodayAttendanceDTO, GetTodayAttendanceResponseViewModel>();
        }
    }
}
