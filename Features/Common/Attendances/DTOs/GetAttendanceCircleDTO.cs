using AutoMapper;
using EasyTask.Models.Attendances;

namespace EasyTask.Features.Common.Attendances.DTOs
{
    public class GetAttendanceCircleDTO
    {
        public TimeSpan ActualStartDate { get; set; }
        public TimeSpan? ActualEndDate { get; set; }
        public TimeSpan? TotalPauseDuration { get; set; }
        public TimeSpan? TotalShiftTime { get; set; }
    }
    public class GetAttendanceCircleDTOProfile : Profile
    {
        public GetAttendanceCircleDTOProfile()
        {
            CreateMap<Attendance, GetAttendanceCircleDTO>()
                .ForMember(dest => dest.ActualStartDate,
                    opt => opt.MapFrom(src => src.ActualStartDate.TimeOfDay))
                .ForMember(dest => dest.ActualEndDate,
                    opt => opt.MapFrom(src => src.ActualEndDate.HasValue
                        ? src.ActualEndDate.Value.TimeOfDay
                        : (TimeSpan?)null))
                .ForMember(dest => dest.TotalShiftTime,
                    opt => opt.MapFrom(src =>
                        src.Shift.ToTime > src.Shift.FromTime
                            ? src.Shift.ToTime - src.Shift.FromTime
                            : (TimeSpan.FromDays(1) - src.Shift.FromTime) + src.Shift.ToTime
                    ));
        }
    }

}
