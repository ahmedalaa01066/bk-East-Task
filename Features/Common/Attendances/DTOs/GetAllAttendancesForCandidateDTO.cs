using AutoMapper;
using EasyTask.Models.Attendances;

namespace EasyTask.Features.Common.Attendances.DTOs
{
    public class GetAllAttendancesForCandidateDTO
    {
        public DateOnly ActualStartDate { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
    }
    public class GetAllAttendancesForCandidateDTOProfile : Profile
    {
        public GetAllAttendancesForCandidateDTOProfile()
        {
            CreateMap<Attendance, GetAllAttendancesForCandidateDTO>()
                .ForMember(dest => dest.ActualStartDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.ActualStartDate)))
                .ForMember(dest => dest.FromTime, opt => opt.MapFrom(src => src.ActualStartDate.TimeOfDay))
                .ForMember(dest => dest.ToTime,
           opt => opt.MapFrom(src => src.ActualEndDate.HasValue ? src.ActualEndDate.Value.TimeOfDay : TimeSpan.Zero));
        }
    }
}
