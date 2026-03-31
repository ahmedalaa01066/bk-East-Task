using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Levels.Queries;

namespace EasyTask.Features.Levels.LevelSelectList
{
    public record LevelSelectListRequestViewModel();
    public class LevelSelectListRequestValidator : AbstractValidator<LevelSelectListRequestViewModel>
    {
        public LevelSelectListRequestValidator() { }
    }
    public class LevelSelectListRequestProfile : Profile
    {
        public LevelSelectListRequestProfile() {
            CreateMap<LevelSelectListRequestViewModel, LevelSelectListQuery>();
        }
    }
}
