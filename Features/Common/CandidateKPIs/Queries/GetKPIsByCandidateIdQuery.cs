using EasyTask.Common.Requests;
using EasyTask.Features.Common.CandidateKPIs.DTOs;
using EasyTask.Models.CandidateKPIs;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.CandidateKPIs.Queries
{
    public record GetKPIsByCandidateIdQuery(string CandidateId) : IRequestBase<GetKPIsByCandidateIdDTO>;
    public class GetKPIsByCandidateIdQueryHandler : RequestHandlerBase<CandidateKPI, GetKPIsByCandidateIdQuery, GetKPIsByCandidateIdDTO>
    {
        public GetKPIsByCandidateIdQueryHandler(RequestHandlerBaseParameters<CandidateKPI> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetKPIsByCandidateIdDTO>> Handle(GetKPIsByCandidateIdQuery request, CancellationToken cancellationToken)
        {

            var candidateKPIs = await _repository
                .Get(c => c.CandidateId == request.CandidateId)
                .Include(c => c.KPI)
                .ToListAsync();

            if (!candidateKPIs.Any())
                return RequestResult<GetKPIsByCandidateIdDTO>.Success(new GetKPIsByCandidateIdDTO
                {
                    KPIsName = new List<string>(),
                    UpdatedDate = null
                });

            var firstThreeNames = candidateKPIs
                .Select(c => c.KPI.Name)
                .Take(3)
                .ToList();

            var mostRecentUpdatedDate = candidateKPIs
                .Max(c => c.UpdatedDate > c.CreatedDate ? c.UpdatedDate.Value : c.CreatedDate);

            var result = new GetKPIsByCandidateIdDTO
            {
                KPIsName = firstThreeNames,
                UpdatedDate = mostRecentUpdatedDate
            };

            return RequestResult<GetKPIsByCandidateIdDTO>.Success(result);
        }
    }
}
