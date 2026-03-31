using AutoMapper;
using EasyTask.Features.Common.Vacations.Queries;
using FluentValidation;

namespace EasyTask.Features.Vacations.VacationsSelectList
{
    public record VacationsSelectListRequestViewModel();
    public class VacationsSelectListRequestValidator : AbstractValidator<VacationsSelectListRequestViewModel>
    {
        public VacationsSelectListRequestValidator()
        {
        }
    }
    public class VacationsSelectListRequestProfile : Profile
    {
        public VacationsSelectListRequestProfile()
        {
            CreateMap<VacationsSelectListRequestViewModel, VacationsSelectListQuery>();
        }
    }
}
