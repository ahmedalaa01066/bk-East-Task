using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Levels.Queries;

namespace EasyTask.Features.Levels.LevelHierarchy
{
    public record LevelHierarchyRequestViewModel(int num);
    public class LevelHierarchyRequestValidator : AbstractValidator<LevelHierarchyRequestViewModel>
    {
        public LevelHierarchyRequestValidator()
        {
        }
    }
    public class LevelHierarchyRequestProfile : Profile
    {
        public LevelHierarchyRequestProfile() {
            CreateMap<LevelHierarchyRequestViewModel, LevelHierarchyQuery>();
        }
    }
}
