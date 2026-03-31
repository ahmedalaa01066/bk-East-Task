using EasyTask.Common.Requests;
using EasyTask.Features.CandidateCourses.UnassignCandidateCourse.Command;
using EasyTask.Models.CandidateCourses;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.CandidateCourses.UnassignCandidateCourse.Orchestrator
{
    public record UnassignCandidateCourseOrchestrator(string CourseId, List<string> CandidateIds) : IRequestBase<bool>;
    public class UnassignCandidateCourseOrchestratorHandler : RequestHandlerBase<CandidateCourse, UnassignCandidateCourseOrchestrator, bool>
    {
        public UnassignCandidateCourseOrchestratorHandler(RequestHandlerBaseParameters<CandidateCourse> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(UnassignCandidateCourseOrchestrator request, CancellationToken cancellationToken)
        {
            foreach (var CandidateId in request.CandidateIds)
            {
                var check = await _mediator.Send(new UnassignCandidateCourseCommand(request.CourseId,CandidateId ));
                if (!check.IsSuccess)
                {
                    return RequestResult<bool>.Failure(check.ErrorCode);
                }
            }
            return RequestResult<bool>.Success(true);
        }
    }
}
