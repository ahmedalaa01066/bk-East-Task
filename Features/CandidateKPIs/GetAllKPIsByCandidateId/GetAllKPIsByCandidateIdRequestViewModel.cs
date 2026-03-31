using AutoMapper;
using EasyTask.Features.Common.CandidateKPIs.Queries;
using FluentValidation;

namespace EasyTask.Features.CandidateKPIs.GetAllKPIsByCandidateId
{
    public record GetAllKPIsByCandidateIdRequestViewModel(string CandidateId);
    public class GetAllKPIsByCandidateIdRequestViewModelValidator : AbstractValidator<GetAllKPIsByCandidateIdRequestViewModel>
    {
        public GetAllKPIsByCandidateIdRequestViewModelValidator()
        {
            RuleFor(x => x.CandidateId).NotEmpty().WithMessage("CandidateId is required.");
        }
    }   
    public class GetAllKPIsByCandidateIdRequestViewModelProfile : Profile
    {
        public GetAllKPIsByCandidateIdRequestViewModelProfile()
        {
            CreateMap<GetAllKPIsByCandidateIdRequestViewModel, GetAllKPIsByCandidateIdQuery>();
        }
    }
}
