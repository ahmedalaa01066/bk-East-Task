using AutoMapper;
using EasyTask.Features.VacationRequests.CreateVacationRequest.Commands;
using FluentValidation;

namespace EasyTask.Features.VacationRequests.CreateVacationRequest
{
    public record CreateVacationRequestRequestViewModel(string? CandidateId, string VacationId,
        DateOnly FromDate, DateOnly ToDate);
    public class CreateVacationRequestValidator : AbstractValidator<CreateVacationRequestRequestViewModel>
    {
        public CreateVacationRequestValidator()
        {
        }
    }
    public class CreateVacationRequestRequestProfile : Profile
    {
        public CreateVacationRequestRequestProfile()
        {
            CreateMap<CreateVacationRequestRequestViewModel, CreateVacationRequestCommand>();
        }
    }
}
