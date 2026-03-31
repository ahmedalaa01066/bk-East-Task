using AutoMapper;
using EasyTask.Features.Common.Courses.Queries;
using FluentValidation;

namespace EasyTask.Features.Courses.GetCourseById
{
    public record GetCourseByIdRequestViewModel(string ID);
    public class GetCourseByIdRequestValidator : AbstractValidator<GetCourseByIdRequestViewModel>
    {
        public GetCourseByIdRequestValidator()
        {
        }
    }
    public class GetCourseByIdRequestProfile : Profile
    {
        public GetCourseByIdRequestProfile()
        {
            CreateMap<GetCourseByIdRequestViewModel, GetCourseByIdQuery>();
        }
    }
}
