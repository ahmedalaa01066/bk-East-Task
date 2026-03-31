using AutoMapper;
using EasyTask.Models.Attendances;

namespace EasyTask.Features.Common.Attendances.DTOs
{
    public record GetShiftAndPauseDurationByIDDTO(string ShiftId, TimeSpan? TotalPauseDuration);
    public class GetShiftAndPauseDurationByIDProfile : Profile
    {
        public GetShiftAndPauseDurationByIDProfile()
        {
            CreateMap<Attendance, GetShiftAndPauseDurationByIDDTO>();
        }
    }
}
