using AutoMapper;
using EasyTask.Models.Candidates;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public record GetManagerByCandidateIdDTO(string ID,string ManagerName,string Email,string Level);
    public class GetManagerByCandidateIdDTOProfile : Profile
    {
        public GetManagerByCandidateIdDTOProfile()
        {
            CreateMap<Candidate, GetManagerByCandidateIdDTO>();
        }
    }
}
