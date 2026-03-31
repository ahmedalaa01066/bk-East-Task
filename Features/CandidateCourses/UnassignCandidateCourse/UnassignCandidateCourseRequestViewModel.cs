using AutoMapper;
using EasyTask.Features.CandidateCourses.UnassignCandidateCourse.Orchestrator;
using FluentValidation;

namespace EasyTask.Features.CandidateCourses.UnassignCandidateCourse
{
    public record UnassignCandidateCourseRequestViewModel(string CourseId,List<string> CandidateIds);
    public class UnassignCandidateCourseRequestViewModelValidator : AbstractValidator<UnassignCandidateCourseRequestViewModel>
    {
        public UnassignCandidateCourseRequestViewModelValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty().WithMessage("Course ID is required.");
            RuleFor(x => x.CandidateIds).NotEmpty().WithMessage("Candidate ID is required.");
        }
    }
    public class UnassignCandidateCourseRequestProfile : Profile
    {
        public UnassignCandidateCourseRequestProfile()
        {
            CreateMap<UnassignCandidateCourseRequestViewModel, UnassignCandidateCourseOrchestrator>();
        }
    }
}
