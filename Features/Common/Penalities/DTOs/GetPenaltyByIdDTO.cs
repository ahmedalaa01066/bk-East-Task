using AutoMapper;
using EasyTask.Models.Penalities;

namespace EasyTask.Features.Common.Penalities.DTOs
{
    public class GetPenaltyByIdDTO
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
    }
    public class GetPenaltyByIdDTOProfile : Profile
    {
        public GetPenaltyByIdDTOProfile()
        {
            CreateMap<Penality, GetPenaltyByIdDTO>()
                .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => src.Candidate.FirstName + src.Candidate.LastName));
        }
    }
}
