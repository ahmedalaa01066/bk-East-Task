using AutoMapper;
using EasyTask.Features.VacationRequests.EditVacationRequest.Commands;
using FluentValidation;

namespace EasyTask.Features.VacationRequests.EditVacationRequest
{
    public record EditVacationRequestRequestViewModel(string ID, DateOnly FromDate, DateOnly ToDate, string VacationId);
    public class EditVacationRequestRequestValidator : AbstractValidator<EditVacationRequestRequestViewModel>
    {
        public EditVacationRequestRequestValidator()
        {
            RuleFor(x => x.ID)
               .NotEmpty().WithMessage("Vacation request ID is required.");

            RuleFor(x => x.FromDate)
                .NotEmpty().WithMessage("FromDate is required.")
                .Must(date => date >= DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("FromDate cannot be in the past.");

            RuleFor(x => x.ToDate)
                .NotEmpty().WithMessage("ToDate is required.")
                .GreaterThan(x => x.FromDate).WithMessage("ToDate must be after FromDate.");
        }
    }
    public class EditVacationRequestRequestProfile : Profile
    {
        public EditVacationRequestRequestProfile()
        {
            CreateMap<EditVacationRequestRequestViewModel, EditVacationRequestCommand>();
        }
    }
}
