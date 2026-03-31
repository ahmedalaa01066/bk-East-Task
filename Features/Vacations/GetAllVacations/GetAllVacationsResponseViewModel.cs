using AutoMapper;
using EasyTask.Features.Common.Vacations.DTOs;

namespace EasyTask.Features.Vacations.GetAllVacations
{
    public record GetAllVacationsResponseViewModel(string ID ,string Name, int MaxRequestNum, int ConfirmationLayerNum);
    public class GetAllVacationsResponseProfile : Profile
    {
        public GetAllVacationsResponseProfile()
        {
            CreateMap<GetAllVacationsDTO, GetAllVacationsResponseViewModel>();
        }
    }
}
