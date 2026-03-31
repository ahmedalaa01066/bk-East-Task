using AutoMapper;
using EasyTask.Models.PauseShifts;

namespace EasyTask.Features.Common.PauseShifts.DTOs
{
    public class PauseShiftDTO
    {
        public TimeSpan FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
    }
    public class PauseShiftDTOProfile : Profile
    {
        public PauseShiftDTOProfile()
        {
            CreateMap<PauseShift, PauseShiftDTO>();
        }
    }
}
