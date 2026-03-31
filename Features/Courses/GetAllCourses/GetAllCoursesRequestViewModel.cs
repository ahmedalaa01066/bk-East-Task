using AutoMapper;
using EasyTask.Features.Common.Courses.Queries;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.Courses.GetAllCourses
{
    public record GetAllCoursesRequestViewModel(
        string? Name,
        CourseClassification? CourseClassification,
        CourseStatus? Status,
        CourseType? CourseType,
        DateTime? From,
        DateTime? To
    );
    public class GetAllCoursesRequestValidator : AbstractValidator<GetAllCoursesRequestViewModel>
    {
        public GetAllCoursesRequestValidator()
        {
        }
    }
    public class GetAllCoursesRequestProfile : Profile
    {
        public GetAllCoursesRequestProfile()
        {
            CreateMap<GetAllCoursesRequestViewModel, GetAllCoursesQuery>();
        }
    }
}
