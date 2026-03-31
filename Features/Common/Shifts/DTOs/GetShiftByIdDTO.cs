using AutoMapper;
using EasyTask.Models.Shifts;

namespace EasyTask.Features.Common.Shifts.DTOs
{
    public class GetShiftByIdDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public bool PauseOption { get; set; }
        public TimeSpan? MaxPauseDuration { get; set; }
        public TimeSpan? MarginBefore { get; set; }
        public TimeSpan? MarginAfter { get; set; }
    }
    public class GetShiftByIdDTOProfile : Profile
    {
        public GetShiftByIdDTOProfile()
        {
            CreateMap<Shift, GetShiftByIdDTO>();
        }
    }
}
