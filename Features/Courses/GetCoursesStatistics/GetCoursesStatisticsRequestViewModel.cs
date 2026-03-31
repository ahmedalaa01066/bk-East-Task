using AutoMapper;
using EasyTask.Features.Common.Courses.Queries;
using FluentValidation;

namespace EasyTask.Features.Courses.GetCoursesStatistics
{
    public record GetCoursesStatisticsRequestViewModel();
    public class GetCoursesStatisticsRequestValidator : AbstractValidator<GetCoursesStatisticsRequestViewModel>
    {
        public GetCoursesStatisticsRequestValidator()
        {
        }
    }
    public class GetCoursesStatisticsRequestProfile : Profile
    {
        public GetCoursesStatisticsRequestProfile()
        {
            CreateMap<GetCoursesStatisticsRequestViewModel, GetCoursesStatisticsQuery>();
        }
    }
}
