using EasyTask.Common.Requests;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Candidates.Queries
{
    public record CandidateSelectListQuery : IRequestBase<IEnumerable<CandidateSelectListDTO>>;
    public class CandidateSelectListQueryHandler : RequestHandlerBase<Candidate, CandidateSelectListQuery, IEnumerable<CandidateSelectListDTO>>
    {
        public CandidateSelectListQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<CandidateSelectListDTO>>> Handle(CandidateSelectListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = await _repository.Get().Map<CandidateSelectListDTO>().ToListAsync();
            return RequestResult<IEnumerable<CandidateSelectListDTO>>.Success(selectListItems);
        }
    }
}
