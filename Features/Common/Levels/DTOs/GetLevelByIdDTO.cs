using AutoMapper;
using EasyTask.Models.Levels;

namespace EasyTask.Features.Common.Levels.DTOs
{
    public record GetLevelByIdDTO(string Id, string Name, int Sequence);
    public class GetLevelByIdDTOProfile : Profile
    {
        public GetLevelByIdDTOProfile()
        {
            CreateMap<Level, GetLevelByIdDTO>();
        }
    }

}
