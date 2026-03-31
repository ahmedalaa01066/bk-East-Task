using AutoMapper;
using EasyTask.Models.Levels;

namespace EasyTask.Features.Common.Levels.DTOs
{
    public record GetAllLevelsDTO(string ID,string Name, int Sequence);
    public class GetAllLevelIndexDTOProfile : Profile
    {
        public GetAllLevelIndexDTOProfile()
        {
            CreateMap<Level, GetAllLevelsDTO>();
        }
    }
}
