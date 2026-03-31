using AutoMapper;
using EasyTask.Features.ExternalMembers.CreateExternalMember.Commands;
using FluentValidation;

namespace EasyTask.Features.ExternalMembers.CreateExternalMember
{
    public record CreateExternalMemberRequestViewModel(
        string Name,
        string Email,
        string PhoneNumber,
        string Notes,
        string Description,
        string PositionId,
        string ExternalCompanyId
    );

    public class CreateExternalMemberRequestValidator : AbstractValidator<CreateExternalMemberRequestViewModel>
    {
        public CreateExternalMemberRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(150).WithMessage("Email must not exceed 150 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[0-9]{8,15}$").WithMessage("Phone number must contain only digits and may include a leading +.")
                .MaximumLength(20).WithMessage("Phone number must not exceed 20 characters.");

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("Notes must not exceed 500 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.PositionId)
                .NotEmpty().WithMessage("Position is required.");

            RuleFor(x => x.ExternalCompanyId)
                .NotEmpty().WithMessage("External company is required.");
        }
    }

    public class CreateExternalMemberRequestProfile : Profile
    {
        public CreateExternalMemberRequestProfile()
        {
            CreateMap<CreateExternalMemberRequestViewModel, CreateExternalMemberCommand>();
        }
    }
}
