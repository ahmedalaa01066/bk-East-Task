using AutoMapper;
using EasyTask.Models.CandidateCourses;

namespace EasyTask.Features.Common.CandidateCourses.DTOs
{
    public class GetAllCandidatesForCourseDTO
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string CandidateEmail { get; set; }
        public string ManagementId { get; set; }
        public string ManagementName { get; set; }
        public DateOnly? ActualStartDate { get; set; }
        public string? Path { get; set; }
    }
    public class GetAllCandidatesForCourseDTOProfile : Profile
    {
        public GetAllCandidatesForCourseDTOProfile()
        {
            CreateMap<CandidateCourse, GetAllCandidatesForCourseDTO>()
                .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => string.Concat(src.Candidate.FirstName, " ", src.Candidate.LastName)))
                .ForMember(dest => dest.CandidateEmail, opt => opt.MapFrom(src => src.Candidate.Email))
                .ForMember(dest => dest.ManagementId, opt => opt.MapFrom(src => src.Candidate.ManagementId))
                .ForMember(dest => dest.ManagementName, opt => opt.MapFrom(src => src.Candidate.Management.Name));
        }
    }
}
