using AutoMapper;
using EasyTask.Models.DefaultKPIs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.DefaultKPIs.DTOs
{
    public class GetAllDefaultKPIsDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public KPIType Type { get; set; }
        public double Percentage { get; set; }
    }
    public class GetAllDefaultKPIsDTOProfile : Profile
    {
        public GetAllDefaultKPIsDTOProfile()
        {
            CreateMap<DefaultKPI,GetAllDefaultKPIsDTO>();
        }
    }
}
