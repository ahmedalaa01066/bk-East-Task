using AutoMapper;
using EasyTask.Features.Common.DefaultKPIs.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.DefaultKPIs.GetAllDefaultKPIs
{
    public class GetAllDefaultKPIsResponseViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public KPIType Type { get; set; }
        public double Percentage { get; set; }
    }
    public class GetAllDefaultKPIsResponseProfile : Profile
    {
        public GetAllDefaultKPIsResponseProfile()
        {
            CreateMap<GetAllDefaultKPIsDTO, GetAllDefaultKPIsResponseViewModel>();
        }
    }
}
