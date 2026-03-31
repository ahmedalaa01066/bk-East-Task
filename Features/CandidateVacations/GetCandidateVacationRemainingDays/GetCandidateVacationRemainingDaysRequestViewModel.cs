using AutoMapper;
using EasyTask.Features.Common.CandidateVacations.Queries;
using FluentValidation;

namespace EasyTask.Features.CandidateVacations.GetCandidateVacationRemainingDays
{
    public record GetCandidateVacationRemainingDaysRequestViewModel(string? CandidateId);
    public class GetCandidateVacationRemainingDaysRequestValidator : AbstractValidator<GetCandidateVacationRemainingDaysRequestViewModel>
    {
        public GetCandidateVacationRemainingDaysRequestValidator()
        {
        }
    }
    public class GetCandidateVacationRemainingDaysRequestProfile : Profile
    {
        public GetCandidateVacationRemainingDaysRequestProfile()
        {
            CreateMap<GetCandidateVacationRemainingDaysRequestViewModel, GetCandidateVacationRemainingDaysQuery>();
        }
    }
}
