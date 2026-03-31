using AutoMapper;
using EasyTask.Features.Common.CandidatePermissions.Queries;
using FluentValidation;

namespace EasyTask.Features.CandidatePermissions.GetAllCandidatePermissions
{
    public record GetAllCandidatePermissionsRequestViewModel(
        string? SearchText,
        int pageIndex = 1,
        int pageSize = 100
    );
    public class GetAllCandidatePermissionsRequestValidator : AbstractValidator<GetAllCandidatePermissionsRequestViewModel>
    {
        public GetAllCandidatePermissionsRequestValidator()
        {
        }
    }
    public class GetAllCandidatePermissionsRequestProfile : Profile
    {
        public GetAllCandidatePermissionsRequestProfile()
        {
            CreateMap<GetAllCandidatePermissionsRequestViewModel, GetAllCandidatePermissionsQuery>();
        }
    }
}
