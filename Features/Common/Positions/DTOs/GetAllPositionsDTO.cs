using AutoMapper;
using EasyTask.Models.Positions;

namespace EasyTask.Features.Common.Positions.DTOs
{
    public record GetAllPositionsDTO(string ID,string Name);
    public class GetAllPositionsDTOProfile : Profile
    {
        public GetAllPositionsDTOProfile()
        {
            CreateMap<Position,GetAllPositionsDTO>();
        }
    }
}
