using AutoMapper;
using EasyTask.Features.Candidates.EditCandidate.Command;
using EasyTask.Features.Candidates.EditCandidate.Orchestrator;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.Candidates.EditCandidate
{
    public record EditCandidateRequestViewModel(
        string ID,
        string FirstName,
        string LastName,
        DateOnly JoiningDate,
        string Email,
        string? Bio,
        string PhoneNumber,
        CandidateStatus CandidateStatus,
        string? ManagerId,
        string? ManagementId,
        string? DepartmentId,
        string LevelId,
        string PositionId,
        string? PositionName,
        string DocumentId,
        List<string>? Paths,
        string? JobId,
        Role? RoleId
    );
    public class EditCandidateRequestValidator : AbstractValidator<EditCandidateRequestViewModel>
    {
        public EditCandidateRequestValidator()
        {
        }
    }
    public class EditCandidateRequestProfile : Profile
    {
        public EditCandidateRequestProfile()
        {
            CreateMap<EditCandidateRequestViewModel, EditCandidateOrchestrator>();
            CreateMap<EditCandidateOrchestrator, EditCandidateCommand>();
        }
    }
}
