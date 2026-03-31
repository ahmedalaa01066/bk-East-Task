using AutoMapper;
using EasyTask.Features.Common.Vacations.Queries;
using FluentValidation;

namespace EasyTask.Features.Vacations.GetByIdVacation
{
    public record GetVacationByIdRequestViewModel(string ID);
    public class GetVacationByIdRequestValidator : AbstractValidator<GetVacationByIdRequestViewModel>
    {
        public GetVacationByIdRequestValidator()
        {
        }
    }
    public class GetVacationByIdRequestProfile : Profile
    {
        public GetVacationByIdRequestProfile()
        {
            CreateMap<GetVacationByIdRequestViewModel, GetVacationByIdQuery>();
        }
    }
}
