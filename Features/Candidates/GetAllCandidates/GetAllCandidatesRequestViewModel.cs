using AutoMapper;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.Candidates.GetAllCandidates
{
    public record GetAllCandidatesRequestViewModel(
        string? SearchText,
         string? ManagementId,
         string? DepartmentId,
         string? LevelId,
         Role? RoleId,
         CandidateStatus? CandidateStatus,
         string? PositionId,
        int pageIndex = 1,
        int pageSize = 100
    );
    public class GetAllCandidatesRequestValidator : AbstractValidator<GetAllCandidatesRequestViewModel>
    {
        public GetAllCandidatesRequestValidator()
        {
        }
    }
    public class GetAllCandidatesRequestProfile : Profile
    {
        public GetAllCandidatesRequestProfile()
        {
            CreateMap<GetAllCandidatesRequestViewModel, GetAllCandidatesQuery>();
        }
    }
}
