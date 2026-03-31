using AutoMapper;
using EasyTask.Features.Common.Shifts.DTOs;

namespace EasyTask.Features.Shifts.GetShiftById
{
    public record GetShiftByIdResponseViewModel(string ID, string Name, TimeSpan FromTime, TimeSpan ToTime, bool PauseOption,
        TimeSpan? MaxPauseDuration, TimeSpan? MarginBefore, TimeSpan? MarginAfter);
    public class GetShiftByIdResponseProfile : Profile
    {
        public GetShiftByIdResponseProfile()
        {
            CreateMap<GetShiftByIdDTO, GetShiftByIdResponseViewModel>();
        }
    }
}
