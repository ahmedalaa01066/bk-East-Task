using AutoMapper;
using EasyTask.Features.VacationRequests.CancelVacationRequest.Commands;
using FluentValidation;

namespace EasyTask.Features.VacationRequests.CancelVacationRequest
{
    public record CancelVacationRequestRequestViewModel(string ID);
    public class CancelVacationRequestRequestValidator : AbstractValidator<CancelVacationRequestRequestViewModel>
    {
        public CancelVacationRequestRequestValidator()
        {
        }
    }
    public class CancelVacationRequestRequestProfile : Profile
    {
        public CancelVacationRequestRequestProfile()
        {
            CreateMap<CancelVacationRequestRequestViewModel, CancelVacationRequestCommand>();
        }
    }
}
