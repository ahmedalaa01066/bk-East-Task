using AutoMapper;
using EasyTask.Features.Common.SpecialDays.Queries;
using FluentValidation;

namespace EasyTask.Features.SpecialDays.GetSpecialDayById
{
    public record GetSpecialDayByIdRequestViewModel(string ID);
    public class GetSpecialDayByIdRequestValidator : AbstractValidator<GetSpecialDayByIdRequestViewModel>
    {
        public GetSpecialDayByIdRequestValidator()
        {
        }
    }
    public class GetSpecialDayByIdRequestProfile : Profile
    {
        public GetSpecialDayByIdRequestProfile()
        {
            CreateMap<GetSpecialDayByIdRequestViewModel, GetSpecialDayByIdQuery>();
        }
    }
}
