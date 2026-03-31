using AutoMapper;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.PlannedShifts.DTOs
{
    public class GetPlannedAttendanceDataByCandidateIdDTO
    {
        public DateTime PlannedStartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public string ShiftId { get; set; }
        public AttendanceActivation AttendanceActivation { get; set; }
        public TimeSpan? MarginBefore { get; set; }
        public TimeSpan? MarginAfter { get; set; }
    }
    public class GetPlannedAttendanceDataByCandidateIdDTOProfile : Profile
    {
        public GetPlannedAttendanceDataByCandidateIdDTOProfile()
        {
            CreateMap<Candidate, GetPlannedAttendanceDataByCandidateIdDTO>();
        }
    }
}
