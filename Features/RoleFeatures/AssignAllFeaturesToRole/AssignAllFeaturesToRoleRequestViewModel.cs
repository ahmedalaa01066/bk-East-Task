using AutoMapper;
using FluentValidation;
using EasyTask.Features.RoleFeatures.AssignAllFeaturesToRole.Commands;

namespace EasyTask.Features.RoleFeatures.AssignAllFeaturesToRole
{
    public record AssignAllFeaturesToRoleRequestViewModel();
    public class AssignAllFeaturesToRoleRequestValidator : AbstractValidator<AssignAllFeaturesToRoleRequestViewModel>
    {
        public AssignAllFeaturesToRoleRequestValidator()
        {
        }
    }
    public class AssignAllFeaturesToRoleRequestProfile : Profile
    {
        public AssignAllFeaturesToRoleRequestProfile()
        {
            CreateMap<AssignAllFeaturesToRoleRequestViewModel, AssignAllFeaturesToRoleCommand>();
        }
    }
}
