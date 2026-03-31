using AutoMapper;
using EasyTask.Features.Courses.DeleteCourse.Commands;
using FluentValidation;

namespace EasyTask.Features.Courses.DeleteCourse
{
    public record DeleteCourseRequestViewModel(string ID);
    public class DeleteCourseRequestValidator : AbstractValidator<DeleteCourseRequestViewModel>
    {
        public DeleteCourseRequestValidator()
        {
        }
    }
    public class DeleteCourseRequestProfile : Profile
    {
        public DeleteCourseRequestProfile()
        {
            CreateMap<DeleteCourseRequestViewModel, DeleteCourseCommand>();
        }
    }
}
