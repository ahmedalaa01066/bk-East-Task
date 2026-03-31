using AutoMapper;
using EasyTask.Features.Common.PlannedShifts.DTOs;

namespace EasyTask.Features.PlannedShifts.GetAllPlannedShiftsByCandidateId
{
    public class GetAllPlannedShiftsByCandidateIdRespnseViewModel
    {
        public string ID { get; set; }
        public string ShiftName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ShiftId { get; set; }
        public string? AttendanceId { get; set; }
    }
    public class GetAllPlannedShiftsByCandidateIdRespnseProfile : Profile
    {
        public GetAllPlannedShiftsByCandidateIdRespnseProfile()
        {
            CreateMap<GetAllPlannedShiftsByCandidateIdDTO, GetAllPlannedShiftsByCandidateIdRespnseViewModel>();
        }
    }

}
