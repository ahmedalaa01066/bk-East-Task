using EasyTask.Common.Requests;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Candidates.Queries
{
    public record GetCandidatesByLevelQuery(string LevelID):IRequestBase<List<CandidateHierarchyDTO>>;
    public class GetCandidatesByLevelQueryHandler : RequestHandlerBase<Candidate, GetCandidatesByLevelQuery, List<CandidateHierarchyDTO>>
    {
        public GetCandidatesByLevelQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<CandidateHierarchyDTO>>> Handle(GetCandidatesByLevelQuery request, CancellationToken cancellationToken)
        {
            var model = _repository.Get(c => c.LevelId == request.LevelID)
                .Include(c => c.Level)
                .Include(c => c.Management)
                .MapList<CandidateHierarchyDTO>().ToList();

            //var model = _repository.Get(c => c.LevelId == request.LevelID)
            //   .Include(c => c.Level)
            //   .Include(c => c.Management)
            //   .AsEnumerable() // switch to LINQ-to-Objects for grouping
            //        .GroupBy(c => c.ManagementId)
            //        .SelectMany(g => g.MapList<CandidateHierarchyDTO>())
            //        .ToList();

            return RequestResult<List<CandidateHierarchyDTO>>.Success(model);
        }
    }
}
