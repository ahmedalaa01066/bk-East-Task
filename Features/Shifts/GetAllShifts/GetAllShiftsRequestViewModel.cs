using AutoMapper;
using EasyTask.Features.Common.Shifts.Queries;
using FluentValidation;

namespace EasyTask.Features.Shifts.GetAllShifts
{
    public record GetAllShiftsRequestViewModel(string? SearchText, int pageIndex = 1,
       int pageSize = 100);
    public class GetAllShiftsRequestValidator : AbstractValidator<GetAllShiftsRequestViewModel>
    {
        public GetAllShiftsRequestValidator()
        {
        }
    }
    public class GetAllShiftsRequestProfile : Profile
    {
        public GetAllShiftsRequestProfile()
        {
            CreateMap<GetAllShiftsRequestViewModel, GetAllShiftsQuery>();
        }
    }
}
