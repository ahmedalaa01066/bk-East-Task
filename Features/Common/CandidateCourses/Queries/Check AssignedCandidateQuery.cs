using EasyTask.Common.Requests;
using EasyTask.Models.CandidateCourses;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.CandidateCourses.Queries
{
    public record Check_AssignedCandidateQuery(string CourseId) : IRequestBase<List<string>>;
    public class Check_AssignedCandidateQueryHandler : RequestHandlerBase<CandidateCourse, Check_AssignedCandidateQuery, List<string>>
    {
        public Check_AssignedCandidateQueryHandler(RequestHandlerBaseParameters<CandidateCourse> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<string>>> Handle(Check_AssignedCandidateQuery request, CancellationToken cancellationToken)
        {
            var candidateIds = await _repository
               .Get(cc => cc.CourseId == request.CourseId)
               .Select(cc => cc.CandidateId)
               .ToListAsync(cancellationToken);

            return RequestResult<List<string>>.Success(candidateIds);
        }
    }
}
