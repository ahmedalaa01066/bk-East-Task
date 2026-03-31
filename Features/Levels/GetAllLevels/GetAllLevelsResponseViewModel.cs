using AutoMapper;
using EasyTask.Features.Common.Levels.DTOs;

namespace EasyTask.Features.Levels.GetLevelIndex
{
    public record GetAllLevelsResponseViewModel(string ID, string Name, int Sequence);
    public class GetLevelIndexResponseProfile : Profile
    {
        public GetLevelIndexResponseProfile()
        {
            CreateMap<GetAllLevelsDTO, GetAllLevelsResponseViewModel>();
        }
    }
}
