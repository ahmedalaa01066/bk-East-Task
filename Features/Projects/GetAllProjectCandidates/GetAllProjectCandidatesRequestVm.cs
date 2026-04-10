using AutoMapper;
using EasyTask.Features.Projects.GetAllProjectCandidates.Queries;
using FluentValidation;

namespace EasyTask.Features.Projects.GetAllProjectCandidates
{
    public record GetAllProjectCandidatesRequestVm(string ProjectId);
    
    public class GetAllProjectCandidatesRequestValidator : AbstractValidator<GetAllProjectCandidatesRequestVm>
    {
        public GetAllProjectCandidatesRequestValidator()
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("Project is required.")
                .NotNull().WithMessage("Project is required.");
        }
    }
    public class GetAllProjectCandidatesRequestProfile : Profile
    {
        public GetAllProjectCandidatesRequestProfile()
        {
            CreateMap<GetAllProjectCandidatesRequestVm, GetAllProjectCandidatesQuery>();
        }
    }
}
