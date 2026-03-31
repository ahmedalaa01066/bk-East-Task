using EasyTask.Common.Requests;
using EasyTask.Models.CandidateCourses;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.CandidateCourses.UnassignCandidateCourse.Command
{
    public record UnassignCandidateCourseCommand(string CourseId, string CandidateId) : IRequestBase<bool>;
    public class UnassignCandidateCourseCommandHandler : RequestHandlerBase<CandidateCourse, UnassignCandidateCourseCommand, bool>
    {
        public UnassignCandidateCourseCommandHandler(RequestHandlerBaseParameters<CandidateCourse> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(UnassignCandidateCourseCommand request, CancellationToken cancellationToken)
        {
            var CandidateCourseID = await _repository.Get(c => c.CourseId == request.CourseId && c.CandidateId == request.CandidateId).Select(c => c.ID).FirstOrDefaultAsync();
            if (CandidateCourseID is not null)
            {
                _repository.Delete(CandidateCourseID);
                _repository.SaveChanges();
            }
            return RequestResult<bool>.Success(true);
        }
    }
}
