using AutoMapper;
using EasyTask.Features.CandidateCourses.UnassignManagmentFromCourse.Command;
using FluentValidation;

namespace EasyTask.Features.CandidateCourses.UnassignManagmentFromCourse
{
    public record UnassignManagmentFromCourseRequestViewModel(string CourseId, List<string> ManagementIds);
    public class UnassignManagmentFromCourseRequestValidator : AbstractValidator<UnassignManagmentFromCourseRequestViewModel>
    {
        public UnassignManagmentFromCourseRequestValidator()
        {
        }
    }
    public class UnassignManagmentFromCourseRequestProfile : Profile
    {
        public UnassignManagmentFromCourseRequestProfile()
        {
            CreateMap<UnassignManagmentFromCourseRequestViewModel, UnassignManagmentFromCourseCommand>();
        }
    }
}
