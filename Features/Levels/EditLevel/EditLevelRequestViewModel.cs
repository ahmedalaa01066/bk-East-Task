using AutoMapper;
using FluentValidation;
using EasyTask.Features.Levels.EditLevel.Commands;

namespace EasyTask.Features.Levels.EditLevel
{
    public record EditLevelRequestViewModel(string Id, string Name, int Sequence);
    public class EditLevelEndPointRequestValidator : AbstractValidator<EditLevelRequestViewModel>
    {
        public EditLevelEndPointRequestValidator()
        {
                 RuleFor(request => request.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 200).WithMessage("Name must be between 2 and 200 characters.");
        }
    }
    public class CreateGroupEndPointRequestProfile : Profile
    {
        public CreateGroupEndPointRequestProfile()
        {
            CreateMap<EditLevelRequestViewModel, EditLevelCommand>();
        }
    }
}