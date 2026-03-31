using AutoMapper;
using EasyTask.Models.Positions;

namespace EasyTask.Features.Common.Positions.DTOs
{
    public record GetPositionByIdDTO(string Id, string Name);
    public class GetPositionByIdDTOProfile : Profile
    {
        public GetPositionByIdDTOProfile()
        {
            CreateMap<Position, GetPositionByIdDTO>();
        }
    }

}
