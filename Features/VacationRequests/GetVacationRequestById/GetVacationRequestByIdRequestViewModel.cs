using AutoMapper;
using EasyTask.Features.Common.VacationRequests.Queries;
using FluentValidation;

namespace EasyTask.Features.VacationRequests.GetByIdVacationRequest
{
    public record GetVacationRequestByIdRequestViewModel(string ID);
    public class GetVacationRequestByIdRequestValidator : AbstractValidator<GetVacationRequestByIdRequestViewModel>
    {
        public GetVacationRequestByIdRequestValidator()
        {
        }
    }
    public class GetVacationRequestByIdRequestProfile : Profile
    {
        public GetVacationRequestByIdRequestProfile()
        {
            CreateMap<GetVacationRequestByIdRequestViewModel, GetVacationRequestByIdQuery>();
        }
    }
}
