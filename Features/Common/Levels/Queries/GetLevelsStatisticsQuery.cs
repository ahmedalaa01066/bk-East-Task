using EasyTask.Common.Requests;
using EasyTask.Features.Common.Levels.DTOs;
using EasyTask.Models.Levels;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Levels.Queries
{
    public record GetLevelsStatisticsQuery():IRequestBase<IEnumerable<GetLevelsStatisticsDTO>>;
    public class GetLevelsStatisticsQueryHandler : RequestHandlerBase<Level, GetLevelsStatisticsQuery, IEnumerable<GetLevelsStatisticsDTO>>
    {
        public GetLevelsStatisticsQueryHandler(RequestHandlerBaseParameters<Level> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<GetLevelsStatisticsDTO>>> Handle(GetLevelsStatisticsQuery request, CancellationToken cancellationToken)
        {
            var levels = await _repository.Get().Include(l => l.Candidates)
                           .Select(l => new GetLevelsStatisticsDTO(
                               l.ID,
                               l.Name,
                               l.Candidates.Count() 
                           )).ToListAsync();

            return RequestResult<IEnumerable<GetLevelsStatisticsDTO>>.Success(levels);
        }
    }
}
