using AutoMapper;
using EasyTask.Features.Common.Positions.DTOs;

namespace EasyTask.Features.Positions.GetAllPositions
{
    public record GetAllPositionsResponseViewModel(string ID, string Name);
    public class GetAllPositionsResponseProfile : Profile
    {
        public GetAllPositionsResponseProfile()
        {
            CreateMap<GetAllPositionsDTO, GetAllPositionsResponseViewModel>();
        }
    }
}
