using AutoMapper;
using EasyTask.Features.Projects.GetAllProjectAvailableCandidates.Queries;
using FluentValidation;

namespace EasyTask.Features.Projects.GetAllProjectAvailableCandidates
{
    public record GetAllProjectAvailableCandidatesRequestViewModel(string ProjectId);
    
    public class GetAllProjectAvailableCandidatesRequestValidator : AbstractValidator<GetAllProjectAvailableCandidatesRequestViewModel>
    {
        public GetAllProjectAvailableCandidatesRequestValidator()
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("Project is required.")
                .NotNull().WithMessage("Project is required.");
        }
    }
    public class GetAllProjectAvailableCandidatesRequestProfile : Profile
    {
        public GetAllProjectAvailableCandidatesRequestProfile()
        {
            CreateMap<GetAllProjectAvailableCandidatesRequestViewModel, GetAllProjectAvailableCandidatesQuery>();
        }
    }
}
