using AutoMapper;
using EasyTask.Features.Common.PlannedShifts.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.PlannedShifts.GetAllCandidatesAssignationShift
{
    public record GetAllCandidatesAssignationShiftRespnseViewModel(
        string ID,
        string Name,
        string DepartmentName,
        string CandidateId,
        string ShiftName,
        string ShiftID,
        string FromTime,
        string ToTime,
    AttendanceActivation AttendanceActivation
    );
    public class GetAllCandidatesAssignationShiftRespnseProfile : Profile
    {
        public GetAllCandidatesAssignationShiftRespnseProfile()
        {
            CreateMap<GetAllCandidatesAssignationShiftDTO, GetAllCandidatesAssignationShiftRespnseViewModel>();
        }
    }

}
