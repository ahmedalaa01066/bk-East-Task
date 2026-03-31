using AutoMapper;
using EasyTask.Features.Jobs.CreateJob.Command;
using FluentValidation;

namespace EasyTask.Features.Jobs.CreateJob
{
    public record CreateJobRequestViewModel(string Name, string Description, string ManagementId);
    public class CreateJobRequestValidator : AbstractValidator<CreateJobRequestViewModel>
    {
        public CreateJobRequestValidator()
        {
            // Name validation
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Job name is required.")
                .MaximumLength(100).WithMessage("Job name cannot exceed 100 characters.");
            
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Job description is required.");

            RuleFor(x => x.ManagementId)
                .NotEmpty().WithMessage("managment id is required.");

        }
    }
    public class CreateJobRequestProfile : Profile
    {
        public CreateJobRequestProfile()
        {
            CreateMap<CreateJobRequestViewModel, CreateJobCommand>();
        }
    }
}
