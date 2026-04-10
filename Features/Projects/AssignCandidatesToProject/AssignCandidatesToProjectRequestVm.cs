using AutoMapper;
using FluentValidation;

namespace EasyTask.Features.Projects.AssignCandidatesToProject;

public record AssignCandidatesToProjectRequestVm(string ProjectId, List<string> CandidateIds);

public class AssignCandidatesToProjectRequestVmValidator : AbstractValidator<AssignCandidatesToProjectRequestVm>
{
    public AssignCandidatesToProjectRequestVmValidator()
    {
        RuleFor(x => x.ProjectId).NotEmpty().WithMessage("ProjectId is required.");
        RuleFor(x => x.CandidateIds).NotEmpty().WithMessage("At least one CandidateId is required.");
    }
}

public class AssignCandidatesToProjectMappingProfile : Profile
{
    public AssignCandidatesToProjectMappingProfile()
    {
        CreateMap<AssignCandidatesToProjectRequestVm, AssignCandidatesToProjectOrchestrator>();
    }
}