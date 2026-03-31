using EasyTask.Common.Requests;
using EasyTask.Features.Common.CandidateKPIs.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.CandidateKPIs;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.CandidateKPIs.Queries
{
    public record GetAllKPIsByCandidateIdQuery(string CandidateId) : IRequestBase<List<GetAllKPIsByCandidateIdDTO>>;
    public class GetAllKPIsByCandidateIdQueryHandler : RequestHandlerBase<CandidateKPI, GetAllKPIsByCandidateIdQuery, List<GetAllKPIsByCandidateIdDTO>>
    {
        public GetAllKPIsByCandidateIdQueryHandler(RequestHandlerBaseParameters<CandidateKPI> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<GetAllKPIsByCandidateIdDTO>>> Handle(GetAllKPIsByCandidateIdQuery request, CancellationToken cancellationToken)
        {

            var candidateKPIs = await _repository
                .Get(c => c.CandidateId == request.CandidateId)
                .Include(c => c.KPI)
                .ToListAsync();

            if (candidateKPIs.Count == 0)
                return RequestResult<List<GetAllKPIsByCandidateIdDTO>>.Success(new List<GetAllKPIsByCandidateIdDTO>());

            var DTO = candidateKPIs.MapList<GetAllKPIsByCandidateIdDTO>().ToList();

            return RequestResult<List<GetAllKPIsByCandidateIdDTO>>.Success(DTO);
        }
    }
}
