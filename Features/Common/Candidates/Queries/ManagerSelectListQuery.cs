using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Candidates.Queries
{
    public record ManagerSelectListQuery() : IRequestBase<IEnumerable<CandidateSelectListDTO>>;
    public class ManagerSelectListQueryHandler : RequestHandlerBase<Candidate, ManagerSelectListQuery, IEnumerable<CandidateSelectListDTO>>
    {
        public ManagerSelectListQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<CandidateSelectListDTO>>> Handle(ManagerSelectListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = await _repository
                .Get(c=> c.User.RoleId == Role.Manager)
                .Include(c=>c.User)
                .Map<CandidateSelectListDTO>()
                .ToListAsync(); ;
            return RequestResult<IEnumerable<CandidateSelectListDTO>>.Success(selectListItems);
        }
    }
}
