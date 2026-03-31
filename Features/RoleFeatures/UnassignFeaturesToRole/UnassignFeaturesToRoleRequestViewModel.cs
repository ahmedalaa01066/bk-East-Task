using AutoMapper;
using FluentValidation;
using EasyTask.Features.RoleFeatures.AssignFeaturesToRole.Commands;
using EasyTask.Features.RoleFeatures.AssignFeaturesToRole;
using EasyTask.Models.Enums;
using EasyTask.Features.RoleFeatures.UnassignFeaturesToRole.Commands;

namespace EasyTask.Features.RoleFeatures.UnassignFeaturesToRole
{
    public record UnassignFeaturesToRoleRequestViewModel(Role RoleId, Feature Feature);

    public class UnassignFeaturesRequestValidator : AbstractValidator<UnassignFeaturesToRoleRequestViewModel>
    {
        public UnassignFeaturesRequestValidator()
        {
            RuleFor(request => request.RoleId)
                           .NotEmpty().WithMessage("RoleId is required.");

            RuleFor(request => request.Feature)
                           .NotNull().WithMessage("Feature is required.");

        }
    }

    public class UnassignFeaturesEndPointProfile : Profile
    {
        public UnassignFeaturesEndPointProfile()
        {
            CreateMap<UnassignFeaturesToRoleRequestViewModel, UnassignFeaturesToRoleCommand>();
        }
    }
}
