using AutoMapper;
using EasyTask.Models.Vacations;

namespace EasyTask.Features.Common.Vacations.DTOs
{
    public class GetVacationByIdDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int MaxRequestNum { get; set; }
        public int ConfirmationLayerNum { get; set; }
    }
    public class GetVacationByIdDTOProfile : Profile
    {
        public GetVacationByIdDTOProfile()
        {
            CreateMap<Vacation, GetVacationByIdDTO>();
        }
    }
}
