using AutoMapper;
using EasyTask.Features.Common.Courses.Queries;
using FluentValidation;

namespace EasyTask.Features.Courses.SelectCourseList
{
    public record SelectCourseListRequestViewModel();
    public class SelectCourseListRequestValidator : AbstractValidator<SelectCourseListRequestViewModel>
    {
        public SelectCourseListRequestValidator()
        {
        }
    }
    public class SelectCourseListRequestProfile : Profile
    {
        public SelectCourseListRequestProfile()
        {
            CreateMap<SelectCourseListRequestViewModel, SelectCourseListQuery>();
        }
    }
}
