using AutoMapper;
using EasyTask.Features.Common.Vacations.DTOs;

namespace EasyTask.Features.Vacations.GetVacationById
{
    public record GetVacationByIdResponseViewModel(string ID ,string Name, int MaxRequestNum, int ConfirmationLayerNum);
    public class GetVacationByIdResponseProfile : Profile
    {
        public GetVacationByIdResponseProfile()
        {
            CreateMap<GetVacationByIdDTO, GetVacationByIdResponseViewModel>();
        }
    }
}
