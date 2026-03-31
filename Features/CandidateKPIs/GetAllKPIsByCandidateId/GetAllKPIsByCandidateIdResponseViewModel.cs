using AutoMapper;
using EasyTask.Features.Common.CandidateKPIs.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.CandidateKPIs.GetAllKPIsByCandidateId
{
    public class GetAllKPIsByCandidateIdResponseViewModel
    {
        public string KPIName { get; set; }
        public KPIType KPIType { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public double Percentage { get; set; }
    }
    public class GetAllKPIsByCandidateIdResponseViewModelProfile : Profile
    {
        public GetAllKPIsByCandidateIdResponseViewModelProfile()
        {
            CreateMap<GetAllKPIsByCandidateIdDTO, GetAllKPIsByCandidateIdResponseViewModel>();
        }
    }
}
