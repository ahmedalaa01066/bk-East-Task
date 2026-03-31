using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.CandidateCourses.Queries;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Features.Common.Courses.DTOs;
using EasyTask.Features.Common.Medias.Queries;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;
using EasyTask.Models.Courses;
using EasyTask.Models.Enums;
using Microsoft.EntityFrameworkCore;
using PredicateExtensions.Core;

namespace EasyTask.Features.Common.Courses.Queries
{
    public record GetAllCoursesQuery(
        string? Name,
        CourseClassification? CourseClassification,
        CourseStatus? Status,
        CourseType? CourseType,
        DateTime? From,
        DateTime? To,
        int pageIndex = 1,
        int pageSize = 100
        ) : IRequestBase<PagingViewModel<GetAllCoursesDTO>>;
    public class GetAllCoursesQueryHandler : RequestHandlerBase<Course, GetAllCoursesQuery, PagingViewModel<GetAllCoursesDTO>>
    {
        public GetAllCoursesQueryHandler(RequestHandlerBaseParameters<Course> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllCoursesDTO>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Course>(true);

            predicate = predicate
                .And(c => string.IsNullOrEmpty(request.Name) || c.Name.Contains(request.Name) || c.InstructorName.Contains(request.Name))
                .And(t => !request.From.HasValue || t.CreatedDate >= request.From.Value)
                .And(t => !request.To.HasValue || t.CreatedDate <= request.To.Value)
                .And(p => !request.CourseClassification.HasValue || p.CourseClassification == request.CourseClassification.Value)
                .And(p => !request.Status.HasValue || p.Status == request.Status.Value)
                .And(p => !request.CourseType.HasValue || p.CourseType == request.CourseType.Value);

            var model = await _repository
                .Get(predicate)
                .Map<GetAllCoursesDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);
            foreach (var item in model.Items)
            {
                item.AssignedManagements = _mediator.Send(new GetAllCandidatesManagmentsForCourseQuery(item.ID))
                        .GetAwaiter().GetResult().Data;
            }
            return RequestResult<PagingViewModel<GetAllCoursesDTO>>.Success(model);
        }
    }
}
