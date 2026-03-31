using AutoMapper;
using EasyTask.Features.Common.CandidateCourses.DTOs;

namespace EasyTask.Features.CandidateCourses.GetAllCandidatesForCourse
{
    public record GetAllCandidatesForCourseResponseViewModel
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
    public class GetAllCandidatesForCourseResponseProfile : Profile
    {
        public GetAllCandidatesForCourseResponseProfile()
        {
            CreateMap<GetAllCandidatesForCourseDTO, GetAllCandidatesForCourseResponseViewModel>();
        }
    }
}
