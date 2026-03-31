using AutoMapper;
using FluentValidation;
using EasyTask.Features.Levels.AddLevel.Commands;

namespace EasyTask.Features.Levels.AddLevel
{
    public record AddLevelRequestViewModel(string Name, int Sequence);
    public class AddLevelRequestValidator : AbstractValidator<AddLevelRequestViewModel>
    {
        public AddLevelRequestValidator() { }
    }
    public class AddLevelRequestProfile : Profile
    {
        public AddLevelRequestProfile() {
            CreateMap<AddLevelRequestViewModel, AddLevelCommand>();
        }
    }
}
