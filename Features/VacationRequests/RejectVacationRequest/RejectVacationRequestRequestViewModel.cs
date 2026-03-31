using AutoMapper;
using EasyTask.Features.VacationRequests.RejectVacationRequest.Commands;
using FluentValidation;

namespace EasyTask.Features.VacationRequests.RejectVacationRequest
{
    public record RejectVacationRequestRequestViewModel(string ID);
    public class RejectVacationRequestRequestValidator : AbstractValidator<RejectVacationRequestRequestViewModel>
    {
        public RejectVacationRequestRequestValidator()
        {
        }
    }
    public class RejectVacationRequestRequestProfile : Profile
    {
        public RejectVacationRequestRequestProfile()
        {
            CreateMap<RejectVacationRequestRequestViewModel, RejectVacationRequestCommand>();
        }
    }
}
