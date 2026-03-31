using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.CandidateCourses.UnassignCandidateCourse.Command;
using EasyTask.Models.CandidateCourses;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.CandidateCourses.UnassignManagmentFromCourse.Command
{
    public record UnassignManagmentFromCourseCommand(string CourseId, List<string> ManagementIds) : IRequestBase<bool>;
    public class UnassignManagmentFromCourseCommandHandler : RequestHandlerBase<CandidateCourse, UnassignManagmentFromCourseCommand, bool>
    {
        public UnassignManagmentFromCourseCommandHandler(RequestHandlerBaseParameters<CandidateCourse> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(UnassignManagmentFromCourseCommand request, CancellationToken cancellationToken)
        {
            foreach (var ManagementId in request.ManagementIds)
            {
                var CandidatesIds = await _repository
                .Get(c => c.CourseId == request.CourseId && c.Candidate.ManagementId == ManagementId)
                .Include(c => c.Candidate)
                .Select(c => c.CandidateId)
                .Distinct()
                .ToListAsync();

                if (CandidatesIds is null || !CandidatesIds.Any())
                {
                    return RequestResult<bool>.Failure(ErrorCode.CandidateCourseNotFound);
                }

                foreach (var item in CandidatesIds)
                {
                    var check = await _mediator.Send(new UnassignCandidateCourseCommand(request.CourseId, item));
                    if (!check.IsSuccess)
                    {
                        return RequestResult<bool>.Failure(check.ErrorCode);
                    }
                }
            }
            
            return RequestResult<bool>.Success(true);
        }
    }
}
