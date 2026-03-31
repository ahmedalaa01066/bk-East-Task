using AutoMapper;
using EasyTask.Features.Common.Shifts.Queries;
using FluentValidation;

namespace EasyTask.Features.Shifts.ShiftSelectList
{
    public record ShiftSelectListRequestViewModel();
    public class ShiftSelectListRequestValidator:AbstractValidator<ShiftSelectListRequestViewModel>
    {
        public ShiftSelectListRequestValidator() { }
    }
    public class ShiftSelectListRequestProfile:Profile
    {
        public ShiftSelectListRequestProfile()
        {
            CreateMap<ShiftSelectListRequestViewModel, ShiftSelectListQuery>();
        }
    }
}
