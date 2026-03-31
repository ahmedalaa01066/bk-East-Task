using AutoMapper;
using EasyTask.Features.CandidateKPIs.UnassignKPIToCandidate.Commands;
using FluentValidation;

namespace EasyTask.Features.CandidateKPIs.UnassignKPIToCandidate
{
    public record UnassignKPIToCandidateRequestViewModel(string CandidateId, string KPIId);
    public class UnassignKPIToCandidateRequestValidator : AbstractValidator<UnassignKPIToCandidateRequestViewModel>
    {
        public UnassignKPIToCandidateRequestValidator()
        {
        }
    }
    public class UnassignKPIToCandidateRequestProfile : Profile
    {
        public UnassignKPIToCandidateRequestProfile()
        {
            CreateMap<UnassignKPIToCandidateRequestViewModel, UnassignKPIToCandidateCommand>();
        }
    }
}
