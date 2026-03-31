using AutoMapper;
using EasyTask.Features.CandidateCourses.AssignCandidatesToCourse.Orchestrators;
using EasyTask.Features.Courses.CreateCourse.Orchestrators;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.CandidateCourses.AssignCandidatesToCourse
{
    public record AssignCandidatesToCourseRequestViewModel(List<string> CandidateIds, string? CourseId, DateOnly StartDate, DateOnly EndDate,
        string? Name, int? Hours, string? InstructorName,
        CourseClassification? CourseClassification, CourseStatus? Status,
        bool? HasExam, CourseType? CourseType, string? Link, string? Content);
    public class AssignCandidatesToCourseRequestValidator : AbstractValidator<AssignCandidatesToCourseRequestViewModel>
    {
        public AssignCandidatesToCourseRequestValidator()
        {
        }
    }
    public class AssignCandidatesToCourseRequestProfile : Profile
    {
        public AssignCandidatesToCourseRequestProfile()
        {
            CreateMap<AssignCandidatesToCourseRequestViewModel, AssignCandidatesToCourseOrchestrator>();
            CreateMap<AssignCandidatesToCourseOrchestrator, CreateCourseOrchestrator>();
        }
    }
}
