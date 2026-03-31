using AutoMapper;
using EasyTask.Features.PlannedShifts.UnassignCandidateToShift.Commands;
using FluentValidation;

namespace EasyTask.Features.PlannedShifts.UnassignCandidateToShift
{
    public record UnassignCandidateToShiftRequestViewModel(string CandidateId, string ShiftId);
    public class UnassignCandidateToShiftRequestValidator : AbstractValidator<UnassignCandidateToShiftRequestViewModel>
    {
        public UnassignCandidateToShiftRequestValidator()
        {
            RuleFor(x => x.CandidateId)
               .NotEmpty().WithMessage("CandidateId is required.");

            RuleFor(x => x.ShiftId)
                .NotEmpty().WithMessage("ShiftId is required.");

        }
    }
    public class UnassignCandidateToShiftRequestProfile : Profile
    {
        public UnassignCandidateToShiftRequestProfile()
        {
            CreateMap<UnassignCandidateToShiftRequestViewModel, UnassignCandidateToShiftCommand>();
        }
    }
}
