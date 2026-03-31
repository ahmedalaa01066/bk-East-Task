using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.RoleFeatures.GetFeaturesByRoleId;
using EasyTask.Models.Enums;

namespace EasyTask.Features.RoleFeatures.GetFeaturesByRoleId
{
    public record GetFeaturesByRoleIdRequestViewModel(Role? RoleId);

    public class GetFeaturesByRoleIdRequestValidator : AbstractValidator<GetFeaturesByRoleIdRequestViewModel>
    {
        public GetFeaturesByRoleIdRequestValidator()
        {
        }
    }

    public class GetFeaturesByRoleIdEndPointProfile : Profile
    {
        public GetFeaturesByRoleIdEndPointProfile()
        {
            CreateMap<GetFeaturesByRoleIdRequestViewModel, GetFeaturesByRoleIdQuery>();
        }
    }
}
