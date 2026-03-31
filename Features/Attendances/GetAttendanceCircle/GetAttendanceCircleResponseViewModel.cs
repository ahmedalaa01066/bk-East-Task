using AutoMapper;
using EasyTask.Features.Common.Attendances.DTOs;
using System;

namespace EasyTask.Features.Attendances.GetAttendanceCircle
{
    public class GetAttendanceCircleResponseViewModel
    {
        public TimeSpan ActualStartDate { get; set; }
        public TimeSpan? ActualEndDate { get; set; }
        public TimeSpan? TotalPauseDuration { get; set; }
        public TimeSpan? TotalShiftTime { get; set; }
    }
    public class GetAttendanceCircleResponseProfile : Profile
    {
        public GetAttendanceCircleResponseProfile()
        {
            CreateMap<GetAttendanceCircleDTO, GetAttendanceCircleResponseViewModel>();
        }
    }
}
