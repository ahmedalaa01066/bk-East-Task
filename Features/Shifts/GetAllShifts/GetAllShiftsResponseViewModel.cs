using AutoMapper;
using EasyTask.Features.Common.Shifts.DTOs;

namespace EasyTask.Features.Shifts.GetAllShifts
{
    public record GetAllShiftsResponseViewModel(string ID, string Name, string FromTime, string ToTime, bool PauseOption,
    string? MaxPauseDuration, List<string>? Assignation, TimeSpan? MarginBefore, TimeSpan? MarginAfter);
    public class GetAllShiftsResponseProfile : Profile
    {
        public GetAllShiftsResponseProfile()
        {
            CreateMap<GetAllShiftsDTO, GetAllShiftsResponseViewModel>();
        }
    }
}
