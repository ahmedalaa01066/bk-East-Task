using EasyTask.Common.Requests;
using EasyTask.Models.Levels;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Levels.Queries
{
    public record GetNextLevelSequenceQuery():IRequestBase<int>;
    public class GetLevelNextSequenceQueryHandler : RequestHandlerBase<Level, GetNextLevelSequenceQuery, int>
    {
        public GetLevelNextSequenceQueryHandler(RequestHandlerBaseParameters<Level> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<int>> Handle(GetNextLevelSequenceQuery request, CancellationToken cancellationToken)
        {
            var maxSequence = await _repository
                .Get()
                .MaxAsync(l => (int?)l.Sequence, cancellationToken) ?? 0;

            var nextSequence = maxSequence + 1;

            return RequestResult<int>.Success(nextSequence);
        }
    }
}
