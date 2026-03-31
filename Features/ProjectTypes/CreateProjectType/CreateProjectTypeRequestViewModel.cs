using AutoMapper;
using EasyTask.Features.ProjectTypes.CreateProjectType.Commands;
using FluentValidation;

namespace EasyTask.Features.ProjectTypes.CreateProjectType
{
    public record CreateProjectTypeRequestViewModel(string Name);
    public class CreateProjectTypeRequestValidator : AbstractValidator<CreateProjectTypeRequestViewModel>
    {
        public CreateProjectTypeRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        }
    }
    public class CreateProjectTypeRequestProfile:Profile
    {
        public CreateProjectTypeRequestProfile()
        {
            CreateMap<CreateProjectTypeRequestViewModel, CreateProjectTypeCommand>();
        }
    }
}
