using AutoMapper;
using EasyTask.Models.CandidateKPIs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.CandidateKPIs.DTOs
{
    public class GetAllKPIsByCandidateIdDTO
    {
        public string KPIName { get; set; }
        public KPIType KPIType { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public double Percentage { get; set; }
    }
    public class GetAllKPIsByCandidateIdDTOProfile : Profile
    {
        public GetAllKPIsByCandidateIdDTOProfile()
        {
            CreateMap<CandidateKPI, GetAllKPIsByCandidateIdDTO>()
                .ForMember(dest => dest.KPIName, opt => opt.MapFrom(src => src.KPI.Name))
                .ForMember(dest => dest.KPIType, opt => opt.MapFrom(src => src.KPI.Type));
        }
    }
}
