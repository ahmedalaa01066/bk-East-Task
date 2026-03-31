using AutoMapper;
using EasyTask.Models.SpecialDays;

namespace EasyTask.Features.Common.SpecialDays.DTOs
{
    public class GetSpecialDayByIdDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly? ToDate { get; set; }
        public bool IsOneDay { get; set; }
    }
    public class GetSpecialDayByIdDTOProfile : Profile
    {
        public GetSpecialDayByIdDTOProfile()
        {
            CreateMap<SpecialDay, GetSpecialDayByIdDTO>();
        }
    }
}
