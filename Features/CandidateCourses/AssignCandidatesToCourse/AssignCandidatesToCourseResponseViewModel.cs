using AutoMapper;
using EasyTask.Features.Common.Courses.DTOs;

namespace EasyTask.Features.CandidateCourses.AssignCandidatesToCourse
{
    public record AssignCandidatesToCourseResponseViewModel(string? ID, string? Path, string? DocumentId);
    public class AssignCandidatesToCourseResponseProfile : Profile
    {
        public AssignCandidatesToCourseResponseProfile()
        {
            CreateMap<CreateCourseDTO, AssignCandidatesToCourseResponseViewModel>();
        }
    }
}
