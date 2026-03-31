using AutoMapper;
using EasyTask.Models.PlannedShifts;

namespace EasyTask.Features.Common.PlannedShifts.DTOs
{
    public class GetAllPlannedShiftsByCandidateIdDTO
    {
        public string ID { get; set; }
        public string ShiftName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ShiftId { get; set; }
        public string? AttendanceId { get; set; }
    }
    public class GetAllPlannedShiftsByCandidateIdDTOProfile : Profile
    {
        public GetAllPlannedShiftsByCandidateIdDTOProfile()
        {
            CreateMap<PlannedShift,GetAllPlannedShiftsByCandidateIdDTO>()
                .ForMember(dest => dest.ShiftName, opt => opt.MapFrom(src => src.Shift.Name));
        }
    }
}
