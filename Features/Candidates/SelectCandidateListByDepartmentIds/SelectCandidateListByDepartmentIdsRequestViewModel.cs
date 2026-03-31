using AutoMapper;
using EasyTask.Features.Common.Candidates.Queries;
using FluentValidation;

namespace EasyTask.Features.Candidates.SelectCandidateListByDepartmentIds
{
    public record SelectCandidateListByDepartmentIdsRequestViewModel(List<string>? DepartmentIds, string? CourseId);
    public class SelectCandidateListByDepartmentIdsRequestValidator : AbstractValidator<SelectCandidateListByDepartmentIdsRequestViewModel>
    {
        public SelectCandidateListByDepartmentIdsRequestValidator()
        {
        }
    }
    public class SelectCandidateListByDepartmentIdsRequestProfile : Profile
    {
        public SelectCandidateListByDepartmentIdsRequestProfile()
        {
            CreateMap<SelectCandidateListByDepartmentIdsRequestViewModel, SelectCandidateListByDepartmentIdsQuery>();
        }
    }
}
