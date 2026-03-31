using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Courses.DTOs;
using EasyTask.Features.Common.Medias.Queries;
using EasyTask.Helpers;
using EasyTask.Models.Courses;
using EasyTask.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Courses.Queries
{
    public record GetCourseByIdQuery(string ID) : IRequestBase<GetCourseByIdDTO>;
    public class GetCourseByIdQueryHandler : RequestHandlerBase<Course, GetCourseByIdQuery, GetCourseByIdDTO>
    {
        public GetCourseByIdQueryHandler(RequestHandlerBaseParameters<Course> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetCourseByIdDTO>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var Course = _repository.Get(c => c.ID == request.ID).Include(c => c.candidateCourses).FirstOrDefault();
            var dto = Course.MapOne<GetCourseByIdDTO>();
            if (Course == null)
            {
                return RequestResult<GetCourseByIdDTO>.Failure(ErrorCode.NotFound);
            }
            dto.CandidateNumber = Course.candidateCourses?
                .Count(cc => cc.Deleted == false) ?? 0;
            var CoursePathsResult = await _mediator.Send(new GetAllMediaForAnySourceQuery(request.ID, SourceType.CourseData));

            var courseWithMedia = dto with
            {
                Paths = CoursePathsResult.IsSuccess
                    ? CoursePathsResult.Data.Select(m => m.Path).ToList()
                    : new List<string>()
            };

            return RequestResult<GetCourseByIdDTO>.Success(courseWithMedia);
        }
    }
}
