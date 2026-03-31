using AutoMapper;
using EasyTask.Models.Shifts;

namespace EasyTask.Features.Common.Shifts.DTOs
{
    public class GetAllShiftsDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public bool PauseOption { get; set; }
        public string? MaxPauseDuration { get; set; }
        public List<string>? Assignation { get; set; }
        public TimeSpan? MarginBefore { get; set; }
        public TimeSpan? MarginAfter { get; set; }
    }
    public class GetAllShiftsDTOProfile : Profile
    {
        public GetAllShiftsDTOProfile()
        {
            CreateMap<Shift, GetAllShiftsDTO>()
                .ForMember(dest => dest.FromTime,
                    opt => opt.MapFrom(src => src.FromTime.ToString(@"hh\:mm")))
                .ForMember(dest => dest.ToTime,
                    opt => opt.MapFrom(src => src.ToTime.ToString(@"hh\:mm")))
                .ForMember(dest => dest.MaxPauseDuration,
                    opt => opt.MapFrom(src => src.MaxPauseDuration.HasValue
                        ? src.MaxPauseDuration.Value.ToString(@"hh\:mm")
                        : null));
        }
    }

}
