using AutoMapper;
using EasyTask.Models.Levels;

namespace EasyTask.Features.Common.Levels.DTOs
{
    public record GetLevelsStatisticsDTO(string ID,string Name,int AssignedCandidatesCount);
    public class GetLevelsStatisticsProfile : Profile
    {
        public GetLevelsStatisticsProfile()
        {
            CreateMap<Level, GetLevelsStatisticsDTO>();
        }
    }
}
