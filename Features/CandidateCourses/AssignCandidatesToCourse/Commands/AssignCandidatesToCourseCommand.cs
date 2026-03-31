using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.CandidateCourses;

namespace EasyTask.Features.CandidateCourses.CreateCandidateCourse.Commands
{
    public record AssignCandidatesToCourseCommand(List<string> CandidateIds, string CourseId, DateOnly StartDate, DateOnly EndDate) : IRequestBase<bool>;
    public class AssignCandidatesToCourseCommandHandler : RequestHandlerBase<CandidateCourse, AssignCandidatesToCourseCommand, bool>
    {
        public AssignCandidatesToCourseCommandHandler(RequestHandlerBaseParameters<CandidateCourse> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AssignCandidatesToCourseCommand request, CancellationToken cancellationToken)
        {
            if (request.CandidateIds == null || !request.CandidateIds.Any())
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            var candidateCourses = request.CandidateIds.Select(candidateId => new CandidateCourse
            {
                CandidateId = candidateId,
                CourseId = request.CourseId,
                StartDate=request.StartDate,
                EndDate=request.EndDate,
            }).ToList();
            _repository.AddRange(candidateCourses);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
