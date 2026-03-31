using AutoMapper;
using EasyTask.Models.CandidateKPIs;

namespace EasyTask.Features.Common.CandidateKPIs.DTOs
{
    public class GetKPIsByCandidateIdDTO
    {
        public List<string> KPIsName { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    public class GetKPIsByCandidateIdDTOProfile : Profile
    {
        public GetKPIsByCandidateIdDTOProfile()
        {
            CreateMap<CandidateKPI, GetKPIsByCandidateIdDTO>();
        }
    }
}
