using AutoMapper;
using EasyTask.Features.CandidateVacations.UpdateCandidateVacationDays.Commands;
using FluentValidation;

namespace EasyTask.Features.CandidateVacations.UpdateCandidateVacationDays
{
    public record UpdateCandidateVacationDaysRequestViewModel(string ID, int Counter);
    public class UpdateCandidateVacationDaysRequestValidator : AbstractValidator<UpdateCandidateVacationDaysRequestViewModel>
    {
        public UpdateCandidateVacationDaysRequestValidator()
        {
            RuleFor(x => x.Counter)
                .GreaterThanOrEqualTo(0).WithMessage("Counter cannot be negative.");
        }
    }
    public class UpdateCandidateVacationDaysRequestProfile : Profile
    {
        public UpdateCandidateVacationDaysRequestProfile()
        {
            CreateMap<UpdateCandidateVacationDaysRequestViewModel, UpdateCandidateVacationDaysCommand>();
        }
    }
}
