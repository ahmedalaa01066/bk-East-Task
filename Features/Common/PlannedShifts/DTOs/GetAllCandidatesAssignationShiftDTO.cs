using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.PlannedShifts;

namespace EasyTask.Features.Common.PlannedShifts.DTOs
{
    public class GetAllCandidatesAssignationShiftDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string DepartmentName {  get; set; }
        public string CandidateId { get; set; }
        public string ShiftName { get; set; }
        public string ShiftID { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public AttendanceActivation AttendanceActivation { get; set; }
    }

    public class GetAllCandidatesAssignationShiftProfile : Profile
    {
        public GetAllCandidatesAssignationShiftProfile()
        {
            CreateMap<PlannedShift, GetAllCandidatesAssignationShiftDTO>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Candidate != null
                        ? src.Candidate.FirstName + " " + src.Candidate.LastName
                        : string.Empty))
                 .ForMember(dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Candidate != null
                    ? src.Candidate.Department.Name
                    : string.Empty))
                .ForMember(dest => dest.CandidateId, opt => opt.MapFrom(src => src.CandidateId))
                .ForMember(dest => dest.ShiftName,
                    opt => opt.MapFrom(src => src.Shift != null ? src.Shift.Name : string.Empty))
                .ForMember(dest => dest.ShiftID, opt => opt.MapFrom(src => src.ShiftId))
                .ForMember(dest => dest.FromTime,
                                    opt => opt.MapFrom(src => $"{src.Shift.FromTime:hh\\:mm}"))
                .ForMember(dest => dest.ToTime,
                                    opt => opt.MapFrom(src => $"{src.Shift.ToTime:hh\\:mm}"))
                .ForMember(dest => dest.AttendanceActivation,
                    opt => opt.MapFrom(src => src.Candidate != null
                        ? src.Candidate.AttendanceActivation
                        : 0));
        }
    }

}
