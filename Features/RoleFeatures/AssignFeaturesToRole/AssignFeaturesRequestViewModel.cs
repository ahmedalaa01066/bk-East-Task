using AutoMapper;
using FluentValidation;
using EasyTask.Features.RoleFeatures.AssignFeaturesToRole.Commands;
using EasyTask.Models.Enums;

namespace EasyTask.Features.RoleFeatures.AssignFeaturesToRole
{
    public record AssignFeaturesRequestViewModel(Role RoleId,Feature Feature );
    public class AssignFeaturesRequestValidator : AbstractValidator<AssignFeaturesRequestViewModel>
    {
        public AssignFeaturesRequestValidator()
        {
            RuleFor(request => request.RoleId)
                           .NotEmpty().WithMessage("RoleId is required.");

            RuleFor(request => request.Feature)
                           .NotNull().WithMessage("Feature is required.");

        }
    }

    public class AssignFeaturesEndPointProfile : Profile
    {
        public AssignFeaturesEndPointProfile() {
            CreateMap<AssignFeaturesRequestViewModel, AssignFeaturesToRoleCommand>();
        }
    }


}
