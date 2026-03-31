using AutoMapper;
using EasyTask.Models.Vacations;

namespace EasyTask.Features.Common.Vacations.DTOs
{
    public class GetAllVacationsDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int MaxRequestNum { get; set; }
        public int ConfirmationLayerNum { get; set; }
    }
    public class GetAllVacationsDTOProfile : Profile
    {
        public GetAllVacationsDTOProfile()
        {
            CreateMap<Vacation, GetAllVacationsDTO>();
        }
    }
}
