using EasyTask.Common.Requests;
using EasyTask.Features.Common.Courses.DTOs;
using EasyTask.Models.Courses;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Courses.Queries
{
    public record GetCoursesStatisticsQuery():IRequestBase<GetCoursesStatisticsDTO>;
    public class GetCoursesStatisticsQueryHandler : RequestHandlerBase<Course, GetCoursesStatisticsQuery, GetCoursesStatisticsDTO>
    {
        public GetCoursesStatisticsQueryHandler(RequestHandlerBaseParameters<Course> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetCoursesStatisticsDTO>> Handle(GetCoursesStatisticsQuery request, CancellationToken cancellationToken)
        {
            var totalCourses = await _repository.Get().Include(c=>c.candidateCourses).CountAsync();

            var assignedCourses = await _repository
                .Get()
                .Where(c => c.candidateCourses.Any())
                .CountAsync();

            var unassignedCourses = totalCourses - assignedCourses;

            var dto = new GetCoursesStatisticsDTO(
                totalCourses,
                assignedCourses,
                unassignedCourses
            );
            return RequestResult<GetCoursesStatisticsDTO>.Success( dto );
        }
    }
}
