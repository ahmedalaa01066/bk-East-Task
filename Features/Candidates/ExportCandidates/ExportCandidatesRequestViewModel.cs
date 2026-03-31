using AutoMapper;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.Candidates.ExportCandidates
{
    public record ExportCandidatesRequestViewModel(string? SearchText,
         string? ManagementId,
         string? DepartmentId,
         string? LevelId,
         CandidateStatus? CandidateStatus,
         string? PositionId);
    public class ExportCandidatesRequestValidator : AbstractValidator<ExportCandidatesRequestViewModel>
    {
        public ExportCandidatesRequestValidator()
        {
        }
    }
    public class ExportCandidatesRequestProfile : Profile
    {
        public ExportCandidatesRequestProfile()
        {
            CreateMap<ExportCandidatesRequestViewModel, ExportCandidatesQuery>();
        }
    }
}
