using AutoMapper;
using EasyTask.Features.Vacations.CreateVacation.Commands;
using FluentValidation;

namespace EasyTask.Features.Vacations.CreateVacation
{
    public record CreateVacationRequestViewModel(string Name, int MaxRequestNum, int ConfirmationLayerNum);
    public class CreateVacationRequestValidator : AbstractValidator<CreateVacationRequestViewModel>
    {
        public CreateVacationRequestValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Vacation name is required.");

            RuleFor(x => x.MaxRequestNum).GreaterThan(0).WithMessage("number of requests must be greater than zero");

        }
    }
    public class CreateVacationRequestProfile : Profile
    {
        public CreateVacationRequestProfile()
        {
            CreateMap<CreateVacationRequestViewModel, CreateVacationCommand>();
        }
    }
}
