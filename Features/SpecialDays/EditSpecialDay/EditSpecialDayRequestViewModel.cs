using AutoMapper;
using EasyTask.Features.SpecialDays.EditSpecialDay.Commands;
using FluentValidation;

namespace EasyTask.Features.SpecialDays.EditSpecialDay
{
    public record EditSpecialDayRequestViewModel(string ID, string Name, DateOnly FromDate, DateOnly? ToDate,
        bool IsOneDay);
    public class EditSpecialDayRequestValidator : AbstractValidator<EditSpecialDayRequestViewModel>
    {
        public EditSpecialDayRequestValidator()
        {
        }
    }
    public class EditSpecialDayRequestProfile : Profile
    {
        public EditSpecialDayRequestProfile()
        {
            CreateMap<EditSpecialDayRequestViewModel, EditSpecialDayCommand>();
        }
    }
}
