using AutoMapper;
using EasyTask.Features.SpecialDays.DeleteSpecialDay.Commands;
using FluentValidation;

namespace EasyTask.Features.SpecialDays.DeleteSpecialDay
{
    public record DeleteSpecialDayRequestViewModel(string ID);
    public class DeleteSpecialDayRequestValidator : AbstractValidator<DeleteSpecialDayRequestViewModel>
    {
        public DeleteSpecialDayRequestValidator()
        {
        }
    }
    public class DeleteSpecialDayRequestProfile : Profile
    {
        public DeleteSpecialDayRequestProfile()
        {
            CreateMap<DeleteSpecialDayRequestViewModel, DeleteSpecialDayCommand>();
        }
    }
}
