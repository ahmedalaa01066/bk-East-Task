using AutoMapper;
using EasyTask.Models.Penalities;

namespace EasyTask.Features.Common.Penalities.DTOs
{
    public class GetPenalitiesByCandidateIdDTO
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } 

    }
    public class GetPenalitiesByCandidateIdDTOProfile : Profile
    {
        public GetPenalitiesByCandidateIdDTOProfile()
        {
            CreateMap<Penality, GetPenalitiesByCandidateIdDTO>();
        }
    }
}
