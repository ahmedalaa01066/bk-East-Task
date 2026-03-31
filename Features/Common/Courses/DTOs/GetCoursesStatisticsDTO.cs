using AutoMapper;
using EasyTask.Models.Courses;

namespace EasyTask.Features.Common.Courses.DTOs
{
    public record GetCoursesStatisticsDTO(int CourseCount, int AssignedCourseCount, int UnassignedCourseCount);
    public class GetCoursesStatisticsProfile : Profile
    {
        public GetCoursesStatisticsProfile()
        {
            CreateMap<Course, GetCoursesStatisticsDTO>();
        }
    }
}
