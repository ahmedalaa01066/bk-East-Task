using EasyTask.Common.Requests;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Features.Common.Levels.DTOs;
using EasyTask.Models.Levels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EasyTask.Features.Common.Levels.Queries
{
    public record LevelHierarchyQuery(int num):IRequestBase<List<LevelHierarchyDTO>>;
    public class LevelHierarchyQueryHandler : RequestHandlerBase<Level, LevelHierarchyQuery, List<LevelHierarchyDTO>>
    {
        public LevelHierarchyQueryHandler(RequestHandlerBaseParameters<Level> requestParameters) : base(requestParameters)
        {
        }
        public override async Task<RequestResult<List<LevelHierarchyDTO>>> Handle(LevelHierarchyQuery request, CancellationToken cancellationToken)
        {
            List<Level>? Levels = await _repository
                 .Get(L => L.Sequence >= request.num && L.Sequence < (request.num + 3))
                 .OrderBy(L => L.Sequence)
                 .Include(L => L.Candidates).ThenInclude(c => c.Management)
                 .ToListAsync();

            if (Levels.IsNullOrEmpty() || Levels[0].Candidates.IsNullOrEmpty())
            {
                return RequestResult<List<LevelHierarchyDTO>>.Success(new List<LevelHierarchyDTO>());
            }

            //first level
            var firstLevelCandidates = Levels[0].Candidates.Where(c => c.ManagementId != null);

            //the main result 
            var result = new List<LevelHierarchyDTO>();

            foreach (var candidateFirstLevel in firstLevelCandidates)
            {
                //second Level
                var candidatesOfSecondLevel = Levels.Count > 1 ? (await _mediator.Send(new GetCandidatesByLevelQuery(Levels[1].ID))) : null;

                //third Level
                if (candidatesOfSecondLevel?.Data != null && Levels.Count > 2 && !Levels[2].Candidates.IsNullOrEmpty())
                {
                    var candidatesOfThirdLevel = await _mediator.Send(new GetCandidatesByLevelQuery(Levels[2].ID));
                    foreach (var candidate in candidatesOfSecondLevel.Data)
                    {
                        candidate.CandidateThirdLevel = candidatesOfThirdLevel.Data;
                    }
                }
                
                //First Level
                var FirstLevel = new LevelHierarchyDTO()
                {
                    LevelId = Levels[0].ID,
                    LevelName = Levels[0].Name,
                    Sequence = Levels[0].Sequence,
                    CandidateID = candidateFirstLevel.ID,
                    CandidateName = $"{candidateFirstLevel.FirstName} {candidateFirstLevel.LastName}",
                    ManagementId = candidateFirstLevel.ManagementId,
                    ManagementName = candidateFirstLevel.Management?.Name ?? "",
                    Candidates = candidatesOfSecondLevel?.Data,
                };
                result.Add(FirstLevel);
            }
            return RequestResult<List<LevelHierarchyDTO>>.Success(result);

        }
    }

}
