using AutoMapper;
using EasyTask.Features.Common.Levels.DTOs;

namespace EasyTask.Features.Levels.GetLevelsStatistics
{
    public record GetLevelsStatisticsResponseViewModel(string ID, string Name, int AssignedCandidatesCount);
    public class GetLevelsStatisticsResponseProfile : Profile
    {
        public GetLevelsStatisticsResponseProfile()
        {
            CreateMap<GetLevelsStatisticsDTO, GetLevelsStatisticsResponseViewModel>();
        }
    }
}
