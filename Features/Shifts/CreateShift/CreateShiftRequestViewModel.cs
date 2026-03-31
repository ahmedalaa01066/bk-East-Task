using AutoMapper;
using EasyTask.Features.Shifts.CreateShift.Commands;
using FluentValidation;

namespace EasyTask.Features.Shifts.CreateShift
{
    public record CreateShiftRequestViewModel(string Name, TimeSpan FromTime, TimeSpan ToTime,
        bool PauseOption, TimeSpan? MaxPauseDuration, TimeSpan? MarginBefore, TimeSpan? MarginAfter);
    public class CreateShiftRequestValidator : AbstractValidator<CreateShiftRequestViewModel>
    {
        public CreateShiftRequestValidator()
        {
            // Name validation
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Shift name is required.")
                .MaximumLength(100).WithMessage("Shift name cannot exceed 100 characters.");

            // Time validation
            RuleFor(x => x.FromTime)
                .NotNull().WithMessage("FromTime is required.");

            RuleFor(x => x.ToTime)
                .NotNull().WithMessage("ToTime is required.")
                .WithMessage("ToTime must be greater than FromTime.");

            // PauseOption + MaxPauseDuration validation
            RuleFor(x => x.MaxPauseDuration)
                .Must((model, pause) => !model.PauseOption || (pause.HasValue && pause.Value > TimeSpan.Zero))
                .WithMessage("If PauseOption is enabled, MaxPauseDuration must be greater than zero.");

        }
    }
    public class CreateShiftRequestProfile : Profile
    {
        public CreateShiftRequestProfile()
        {
            CreateMap<CreateShiftRequestViewModel, CreateShiftCommand>();
        }
    }
}
