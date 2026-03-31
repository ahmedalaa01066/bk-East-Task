using AutoMapper;
using EasyTask.Features.CandidateKPIs.AssignKPIToCandidate.Orchestrators;
using EasyTask.Features.KPIs.CreateKPI.Commands;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.CandidateKPIs.AssignKPIToCandidate
{
    public record AssignKPIToCandidateRequestViewModel(
        string Name, KPIType Type, string CandidateId, double Percentage
        );
    public class AssignKPIToCandidateRequestValidator : AbstractValidator<AssignKPIToCandidateRequestViewModel>
    {
        public AssignKPIToCandidateRequestValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("KPI Name is required.")
               .MaximumLength(100).WithMessage("KPI Name must not exceed 100 characters.");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Invalid KPI Type.");

            RuleFor(x => x.CandidateId)
                .NotEmpty().WithMessage("CandidateId is required.");

            RuleFor(x => x.Percentage)
                .GreaterThan(0).WithMessage("Percentage must be greater than 0.")
                .LessThanOrEqualTo(100).WithMessage("Percentage must not exceed 100.");
        }
    }
    public class AssignKPIToCandidateRequestProfile : Profile
    {
        public AssignKPIToCandidateRequestProfile()
        {
            CreateMap<AssignKPIToCandidateRequestViewModel, AssignKPIToCandidateOrchestrator>();
            CreateMap<AssignKPIToCandidateOrchestrator, CreateKPICommand>();
        }
    }
}
