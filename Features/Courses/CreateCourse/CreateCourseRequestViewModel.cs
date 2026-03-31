using AutoMapper;
using EasyTask.Features.CandidateCourses.CreateCandidateCourse.Commands;
using EasyTask.Features.Courses.CreateCourse.Commands;
using EasyTask.Features.Courses.CreateCourse.Orchestrators;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.Courses.CreateCourse
{
    public record CreateCourseRequestViewModel(
        string Name, int Hours, string InstructorName,
        CourseClassification CourseClassification, CourseStatus Status,
        bool HasExam, CourseType CourseType,  string Link, string Content
        );
    public class CreateCourseRequestValidator : AbstractValidator<CreateCourseRequestViewModel>
    {
        public CreateCourseRequestValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Course name is required.")
            .MaximumLength(100).WithMessage("Course name must not exceed 100 characters.");


            RuleFor(x => x.Hours)
                .GreaterThan(0).WithMessage("Course hours must be greater than zero.")
                .LessThanOrEqualTo(100).WithMessage("Course hours must not exceed 100.");

            RuleFor(x => x.InstructorName)
                .NotEmpty().WithMessage("Instructor name is required.")
                .MaximumLength(100).WithMessage("Instructor name must not exceed 100 characters.");

            RuleFor(x => x.CourseClassification)
                .IsInEnum().WithMessage("Invalid course classification.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid course status.");

            RuleFor(x => x.CourseType)
                .IsInEnum().WithMessage("Invalid course type.");

            RuleFor(x => x.Link)
               .NotEmpty().WithMessage("Course link is required.")
               .MaximumLength(255).WithMessage("Course link must not exceed 255 characters.")
               .Matches(@"^(https?:\/\/)?([\w\-]+\.)+[\w\-]+(\/[\w\-._~:/?#[\]@!$&'()*+,;=]*)?$")
               .WithMessage("Invalid course link format.");
        }
    }
    public class CreateCourseRequestProfile : Profile
    {
        public CreateCourseRequestProfile()
        {
            CreateMap<CreateCourseRequestViewModel, CreateCourseOrchestrator>();
            CreateMap<CreateCourseOrchestrator, CreateCourseCommand>();
            CreateMap<CreateCourseOrchestrator, AssignCandidatesToCourseCommand>();
        }
    }
}
