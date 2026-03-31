using AutoMapper;
using EasyTask.Features.Common.Levels.DTOs;

namespace EasyTask.Features.Levels.GetLevelById
{
    public record GetLevelByIdResponseViewModel(string Id, string Name, int Sequence);
    public class GetLevelByIdResponseProfile : Profile
    {
        public GetLevelByIdResponseProfile()
        {
            CreateMap<GetLevelByIdDTO, GetLevelByIdResponseViewModel>();
        }
    }
}
