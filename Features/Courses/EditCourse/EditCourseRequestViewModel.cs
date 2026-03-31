using AutoMapper;
using EasyTask.Features.Courses.EditCourse.Command;
using EasyTask.Features.Courses.EditCourse.Orchestrators;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.Courses.EditCourse
{
    public record EditCourseRequestViewModel(
        string ID,
        string Name,
        int Hours,
        string InstructorName,
        CourseClassification CourseClassification,
        CourseStatus Status,
        bool HasExam,
        CourseType CourseType,
        string Link,
        string Content
         //List<string>? Paths
    );
    public class EditCourseRequestValidator : AbstractValidator<EditCourseRequestViewModel>
    {
        public EditCourseRequestValidator()
        {
        }
    }
    public class EditCourseRequestProfile : Profile
    {
        public EditCourseRequestProfile()
        {
            CreateMap<EditCourseRequestViewModel, EditCourseOrchestrator>();
            CreateMap<EditCourseOrchestrator, EditCourseCommand>();
        }
    }
}
