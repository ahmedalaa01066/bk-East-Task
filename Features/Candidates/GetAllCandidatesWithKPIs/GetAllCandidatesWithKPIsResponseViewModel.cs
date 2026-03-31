using AutoMapper;
using EasyTask.Features.Common.CandidateKPIs.DTOs;
using EasyTask.Features.Common.Candidates.DTOs;

namespace EasyTask.Features.Candidates.GetAllCandidatesWithKPIs
{
    public record GetAllCandidatesWithKPIsResponseViewModel(string ID, string Name,
    string PositionName, string? Path, GetKPIsByCandidateIdDTO CandidateKPIs);
    public class GetAllCandidatesWithKPIsResponseProfile : Profile
    {
        public GetAllCandidatesWithKPIsResponseProfile()
        {
            CreateMap<GetAllCandidatesWithKPIsDTO, GetAllCandidatesWithKPIsResponseViewModel>();
        }
    }
}
