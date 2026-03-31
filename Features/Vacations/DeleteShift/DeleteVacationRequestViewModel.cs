using AutoMapper;
using EasyTask.Features.Vacations.DeleteVacation.Commands;
using FluentValidation;

namespace EasyTask.Features.Vacations.DeleteVacation
{
    public record DeleteVacationRequestViewModel(string ID);
    public class DeleteVacationRequestValidator : AbstractValidator<DeleteVacationRequestViewModel>
    {
        public DeleteVacationRequestValidator()
        {
        }
    }
    public class DeleteVacationRequestProfile : Profile
    {
        public DeleteVacationRequestProfile()
        {
            CreateMap<DeleteVacationRequestViewModel, DeleteVacationCommand>();
        }
    }
}
