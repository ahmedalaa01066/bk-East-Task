using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Levels.Queries;
using System.Security.Policy;

namespace EasyTask.Features.Levels.GetLevelIndex
{
    public record GetAllLevelsRequestViewModel(string? Name, int pageIndex = 1, int pageSize = 100);
    public class GetLevelIndexRequestValidator : AbstractValidator<GetAllLevelsRequestViewModel>
    {
        public GetLevelIndexRequestValidator()
        {
        }
    }
    public class GetLevelIndexRequestProfile : Profile
    {
        public GetLevelIndexRequestProfile() {
            CreateMap<GetAllLevelsRequestViewModel, GetAllLevelsQuery>();
        }
    }
}
