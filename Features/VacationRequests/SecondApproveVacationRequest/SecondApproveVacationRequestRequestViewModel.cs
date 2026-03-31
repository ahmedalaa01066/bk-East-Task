using AutoMapper;
using EasyTask.Features.VacationRequests.SecondApproveVactionRequest.Commands;
using EasyTask.Features.VacationRequests.SecondApproveVactionRequest.Orchestrator;
using FluentValidation;

namespace EasyTask.Features.VacationRequests.SecondApproveVactionRequest
{
    public record SecondApproveVacationRequestRequestViewModel(string ID);
    public class SecondApproveVacationRequestRequestValidator : AbstractValidator<SecondApproveVacationRequestRequestViewModel>
    {
        public SecondApproveVacationRequestRequestValidator()
        {
        }
    }
    public class SecondApproveVacationRequestRequestProfile : Profile
    {
        public SecondApproveVacationRequestRequestProfile()
        {
            CreateMap<SecondApproveVacationRequestRequestViewModel, SecondApproveVacationRequestOrchestrator>();
            CreateMap<SecondApproveVacationRequestOrchestrator, SecondApproveVacationRequestCommand>();
        }
    }
}
