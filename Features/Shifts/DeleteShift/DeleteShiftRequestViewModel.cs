using AutoMapper;
using EasyTask.Features.Shifts.DeleteShift.Commands;
using FluentValidation;

namespace EasyTask.Features.Shifts.DeleteShift
{
    public record DeleteShiftRequestViewModel(string ID);
    public class DeleteShiftRequestValidator : AbstractValidator<DeleteShiftRequestViewModel>
    {
        public DeleteShiftRequestValidator()
        {
        }
    }
    public class DeleteShiftRequestProfile : Profile
    {
        public DeleteShiftRequestProfile()
        {
            CreateMap<DeleteShiftRequestViewModel, DeleteShiftCommand>();
        }
    }
}
