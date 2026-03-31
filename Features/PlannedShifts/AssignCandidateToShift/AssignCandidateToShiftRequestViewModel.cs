using AutoMapper;
using EasyTask.Features.PlannedShifts.AssignCandidateToShift.Orchestartor;
using FluentValidation;

namespace EasyTask.Features.PlannedShifts.AssignCandidateToShift
{
    public record AssignCandidateToShiftRequestViewModel(
        DateTime StartDate,
        DateTime EndDate, 
        List<string> CandidateIds,
        string ShiftId
        );
    public class AssignCandidateToShiftRequestViewModelValidator : AbstractValidator<AssignCandidateToShiftRequestViewModel>
    {
        public AssignCandidateToShiftRequestViewModelValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("StartDate is required.");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("EndDate is required.")
                .GreaterThan(x => x.StartDate).WithMessage("EndDate must be greater than StartDate.");
            RuleFor(x => x.CandidateIds).NotEmpty().WithMessage("CandidateId is required.");
            RuleFor(x => x.ShiftId).NotEmpty().WithMessage("ShiftId is required.");
        }
    }
    public class AssignCandidateToShiftRequestViewModelProfile : Profile
    {
        public AssignCandidateToShiftRequestViewModelProfile()
        {
            CreateMap<AssignCandidateToShiftRequestViewModel, AssignCandidateToShiftOrchestartor>();
        }
    }
}
