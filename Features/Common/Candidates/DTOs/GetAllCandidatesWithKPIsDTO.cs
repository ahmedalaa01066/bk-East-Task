using AutoMapper;
using EasyTask.Features.Common.CandidateKPIs.DTOs;
using EasyTask.Models.Candidates;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public class GetAllCandidatesWithKPIsDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string PositionName { get; set; }
        public string? Path { get; set; }
        public GetKPIsByCandidateIdDTO? CandidateKPIs { get; set; }

    }
    public class GetAllCandidatesWithKPIsDTOProfile : Profile
    {
        public GetAllCandidatesWithKPIsDTOProfile()
        {
            CreateMap<Candidate, GetAllCandidatesWithKPIsDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName}  {src.LastName}"))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.Name))
                .ForMember(dest => dest.CandidateKPIs, opt => opt.Ignore());
        }
    }
}
