using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Courses.DTOs;
using EasyTask.Features.Common.Documents.Queries;
using EasyTask.Helpers;
using EasyTask.Models.Courses;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.Courses.Queries
{
    public record GetAllCoursesByCandidateIdQuery(string CandidateId, int pageIndex = 1, int pageSize = 100)
        : IRequestBase<PagingViewModel<GetAllCoursesByCandidateIdDTO>>;

    public class GetAllCoursesByCandidateIdQueryHandler
        : RequestHandlerBase<Course, GetAllCoursesByCandidateIdQuery, PagingViewModel<GetAllCoursesByCandidateIdDTO>>
    {
        public GetAllCoursesByCandidateIdQueryHandler(RequestHandlerBaseParameters<Course> requestParameters)
            : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllCoursesByCandidateIdDTO>>> Handle(
            GetAllCoursesByCandidateIdQuery request,
            CancellationToken cancellationToken)
        {
            var model = await _repository
                .Get(c => c.candidateCourses.Any(cc => cc.CandidateId == request.CandidateId))
                .Select(c => new GetAllCoursesByCandidateIdDTO
                {
                    ID = c.ID,
                    Name = c.Name,
                    Hours = c.Hours,
                    InstructorName = c.InstructorName,
                    CourseClassification = c.CourseClassification,
                    Status = c.Status,
                    HasExam = c.HasExam,
                    CourseType = c.CourseType,
                    Link = c.Link,
                    Content = c.Content,
                    StartDate = c.candidateCourses
                        .Where(cc => cc.CandidateId == request.CandidateId)
                        .Select(cc => cc.StartDate)
                        .FirstOrDefault(),
                    EndDate = c.candidateCourses
                        .Where(cc => cc.CandidateId == request.CandidateId)
                        .Select(cc => cc.EndDate)
                        .FirstOrDefault(),
                    ActualStartDate = c.candidateCourses
                        .Where(cc => cc.CandidateId == request.CandidateId)
                        .Select(cc => cc.ActualStartDate)
                        .FirstOrDefault(),
                })
                .ToPagesAsync(request.pageIndex, request.pageSize);

            foreach (var course in model.Items)
            {
                var document = await _mediator.Send(
                    new GetDocumentIdBySourceIdAndTypeQuery(course.ID, DocumentType.Course),
                    cancellationToken
                );

                if (document.IsSuccess && document.Data != null)
                {
                    course.DocumentId = document.Data.ID;
                }
            }

            return RequestResult<PagingViewModel<GetAllCoursesByCandidateIdDTO>>.Success(model);
        }
    }
}
