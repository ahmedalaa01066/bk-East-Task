using AutoMapper;
using EasyTask.Features.SpecialDays.AddSpecialDay.Command;
using FluentValidation;

namespace EasyTask.Features.SpecialDays.AddSpecialDay
{
    public record AddSpecialDayRequestViewModel(string Name, DateOnly FromDate, DateOnly? ToDate, bool IsOneDay);
    public class AddSpecialDayRequestValidator : AbstractValidator<AddSpecialDayRequestViewModel>
    {
        public AddSpecialDayRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(x => x.FromDate)
                .NotEmpty()
                .WithMessage("FromDate is required.");

            RuleFor(x => x)
                .Must(x => !x.ToDate.HasValue || x.FromDate <= x.ToDate.Value)
                .WithMessage("ToDate must be greater than or equal to FromDate.");

            RuleFor(x => x)
                .Must(x => !x.IsOneDay || !x.ToDate.HasValue || x.FromDate == x.ToDate.Value)
                .WithMessage("If IsOneDay is true, ToDate must be null or equal to FromDate.");

        }
    }
    public class AddSpecialDayRequestProfile : Profile
    {
        public AddSpecialDayRequestProfile()
        {
            CreateMap<AddSpecialDayRequestViewModel, AddSpecialDayCommand>();
        }
    }
}
