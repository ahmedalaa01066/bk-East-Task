using AutoMapper;
using EasyTask.Features.Shifts.EditShift.Commands;
using FluentValidation;

namespace EasyTask.Features.Shifts.EditShift
{
    public record EditShiftRequestViewModel(
       string ID,
        string Name,
        TimeSpan FromTime,
        TimeSpan ToTime,
        bool PauseOption,
        TimeSpan? MaxPauseDuration,
        TimeSpan? MarginBefore,
        TimeSpan? MarginAfter
    );
    public class EditShiftRequestValidator : AbstractValidator<EditShiftRequestViewModel>
    {
        public EditShiftRequestValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Shift name is required.")
                .MaximumLength(100).WithMessage("Shift name cannot exceed 100 characters.");

            RuleFor(x => x.FromTime)
                .NotNull().WithMessage("FromTime is required.");

            RuleFor(x => x.ToTime)
                .NotNull().WithMessage("ToTime is required.")
                .WithMessage("ToTime must be greater than FromTime.");

            RuleFor(x => x.MaxPauseDuration)
                .Must((model, pause) => !model.PauseOption || pause.HasValue && pause.Value > TimeSpan.Zero)
                .WithMessage("If PauseOption is enabled, MaxPauseDuration must be greater than zero.");

        }
    }
    public class EditShiftRequestProfile : Profile
    {
        public EditShiftRequestProfile()
        {
            CreateMap<EditShiftRequestViewModel, EditShiftCommand>();
        }
    }
}
