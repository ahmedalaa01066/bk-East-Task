using AutoMapper;
using EasyTask.Features.Common.Shifts.Queries;
using FluentValidation;

namespace EasyTask.Features.Shifts.GetShiftById
{
    public record GetShiftByIdRequestViewModel(string ID);
    public class GetShiftByIdRequestValidator : AbstractValidator<GetShiftByIdRequestViewModel>
    {
        public GetShiftByIdRequestValidator()
        {
        }
    }
    public class GetShiftByIdRequestProfile : Profile
    {
        public GetShiftByIdRequestProfile()
        {
            CreateMap<GetShiftByIdRequestViewModel, GetShiftByIDQuery>();
        }
    }
}
