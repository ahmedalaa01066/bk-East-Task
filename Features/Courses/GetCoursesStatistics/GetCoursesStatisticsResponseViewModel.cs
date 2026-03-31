using AutoMapper;
using EasyTask.Features.Common.Courses.DTOs;

namespace EasyTask.Features.Courses.GetCoursesStatistics
{
    public record GetCoursesStatisticsResponseViewModel(int CourseCount, int AssignedCourseCount, int UnassignedCourseCount);
    public class GetCoursesStatisticsResponseProfile : Profile
    {
        public GetCoursesStatisticsResponseProfile()
        {
            CreateMap<GetCoursesStatisticsDTO, GetCoursesStatisticsResponseViewModel>();
        }
    }
}
