using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Models.Candidates;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EasyTask.Features.Common.Candidates.Queries
{
    public record GetManagerByCandidateIdQuery(string ID):IRequestBase<GetManagerByCandidateIdDTO>;
    public class GetManagerByCandidateIdQueryHandler : RequestHandlerBase<Candidate, GetManagerByCandidateIdQuery, GetManagerByCandidateIdDTO>
    {
        public GetManagerByCandidateIdQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetManagerByCandidateIdDTO>> Handle(GetManagerByCandidateIdQuery request, CancellationToken cancellationToken)
        {
            var candidate =  _repository.Get(c => c.ID == request.ID)
                .Include(c => c.Manager)
                .ThenInclude(m => m.Level).FirstOrDefault();
            if (candidate == null || candidate.Manager == null)
                return RequestResult<GetManagerByCandidateIdDTO>.Failure(ErrorCode.NotFound,"Manager not found");

            var dto = new GetManagerByCandidateIdDTO(
                candidate.Manager.ID,
                $"{candidate.Manager.FirstName} {candidate.Manager.LastName}",
                candidate.Manager.Email,
                candidate.Manager.Level?.Name ?? string.Empty
            );

            return RequestResult<GetManagerByCandidateIdDTO>.Success(dto);
        }
    }
}
