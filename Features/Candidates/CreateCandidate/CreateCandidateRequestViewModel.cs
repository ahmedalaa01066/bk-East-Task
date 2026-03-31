using AutoMapper;
using EasyTask.Features.Candidates.CreateCandidate;
using EasyTask.Features.Candidates.CreateCandidate.Orchestrator;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.Candidates.CreateCandidate
{
    public record CreateCandidateRequestViewModel(
    string FirstName,
    string LastName,
    string Password,
    string ConfirmPassword,
    DateOnly JoiningDate,
    string Email,
    string PhoneNumber,
    CandidateStatus CandidateStatus,
    string? ManagerId,
    string? ManagementId,
    string? DepartmentId,
    string LevelId,
    string PositionId,
    string? PositionName,
    string? Bio,
     string? JobId,
     Role RoleId
    );
    public class CreateCandidateRequestValidator : AbstractValidator<CreateCandidateRequestViewModel>
    {
        public CreateCandidateRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name must be less than 50 characters.");
            
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name must be less than 50 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Passwords do not match.");

            RuleFor(x => x.JoiningDate)
                .NotEmpty().WithMessage("Joining date is required.")
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Joining date cannot be in the future.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^01[0125][0-9]{8}$").WithMessage("Invalid Egyptian mobile number format.");

            RuleFor(x => x.CandidateStatus)
                .IsInEnum().WithMessage("Invalid candidate status.");

            RuleFor(x => x.LevelId)
                .NotEmpty().WithMessage("Level ID is required.");

            RuleFor(x => x.PositionId)
                .NotEmpty().WithMessage("Position ID is required.");

            RuleFor(x => x.PositionName)
                .MaximumLength(100).WithMessage("Position name must be less than 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.PositionName));

        }

    }
}
    public class CreateCandidateRequestProfile : Profile
    {
        public CreateCandidateRequestProfile()
        {
            CreateMap<CreateCandidateRequestViewModel, CreateCandidateOrchestrator>();
        }
    }

