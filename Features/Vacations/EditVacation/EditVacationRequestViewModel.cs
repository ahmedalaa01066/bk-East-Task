using AutoMapper;
using EasyTask.Features.Vacations.EditVacation.Commands;
using FluentValidation;

namespace EasyTask.Features.Vacations.EditVacation
{
    public record EditVacationRequestViewModel(string ID,string Name, int MaxRequestNum, int ConfirmationLayerNum);
    public class EditVacationRequestValidator : AbstractValidator<EditVacationRequestViewModel>
    {
        public EditVacationRequestValidator()
        {
            RuleFor(x => x.MaxRequestNum).GreaterThan(0).WithMessage("number of requests must be greater than zero");
        }
    }
    public class EditVacationRequestProfile : Profile
    {
        public EditVacationRequestProfile()
        {
            CreateMap<EditVacationRequestViewModel, EditVacationCommand>();
        }
    }
}
