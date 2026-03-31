using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.CandidateCourses.DTOs;
using EasyTask.Features.Common.Medias.Queries;
using EasyTask.Helpers;
using EasyTask.Models.CandidateCourses;
using EasyTask.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.CandidateCourses.Queries
{
    public record GetAllCandidatesForCourseQuery(string CourseId,
        int pageIndex = 1,
        int pageSize = 100) : IRequestBase<PagingViewModel<GetAllCandidatesForCourseDTO>>;
    public class GetAllCandidatesForCourseQueryHandler : RequestHandlerBase<CandidateCourse, GetAllCandidatesForCourseQuery, PagingViewModel<GetAllCandidatesForCourseDTO>>
    {
        public GetAllCandidatesForCourseQueryHandler(RequestHandlerBaseParameters<CandidateCourse> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllCandidatesForCourseDTO>>> Handle(GetAllCandidatesForCourseQuery request, CancellationToken cancellationToken)
        {

            var model = await _repository
                .Get(c => c.CourseId == request.CourseId)
                .Include(c => c.Candidate)
                .ThenInclude(c => c.Management)
                .Map<GetAllCandidatesForCourseDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);
            foreach (var item in model.Items)
            {
                var mediaResult = await _mediator.Send(new GetMediaForAnySourceQuery(item.CandidateId, SourceType.CandidateImage));
                item.Path = mediaResult.Data;
            }
            return RequestResult<PagingViewModel<GetAllCandidatesForCourseDTO>>.Success(model);
        }
    }
}
