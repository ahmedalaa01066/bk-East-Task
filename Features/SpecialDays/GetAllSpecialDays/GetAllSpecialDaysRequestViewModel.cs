using AutoMapper;
using EasyTask.Features.Common.SpecialDays.Queries;
using FluentValidation;

namespace EasyTask.Features.SpecialDays.GetAllSpecialDays
{
    public record GetAllSpecialDaysRequestViewModel
        (string? Name, DateOnly? From, DateOnly? To, int pageIndex = 1, int pageSize = 100);
    public class GetAllSpecialDaysRequestValidator : AbstractValidator<GetAllSpecialDaysRequestViewModel>
    {
        public GetAllSpecialDaysRequestValidator()
        {
        }
    }
    public class GetAllSpecialDaysRequestProfile : Profile
    {
        public GetAllSpecialDaysRequestProfile()
        {
            CreateMap<GetAllSpecialDaysRequestViewModel, GetAllSpecialDaysQuery>();
        }
    }
}
