using AutoMapper;
using FluentValidation;
using EasyTask.Models.Enums;
using EasyTask.Features.RoleFeatures.AssignBulkFeaturesToRole.Commands;

namespace EasyTask.Features.RoleFeatures.AssignBulkFeatuersToRole
{
    public record AssignBulkFeatuersToRoleRequestViewModel(Role RoleId, IEnumerable<Feature> Features);
    public class AssignBulkFeatuersToRoleRequestValidator : AbstractValidator<AssignBulkFeatuersToRoleRequestViewModel>
    {
        public AssignBulkFeatuersToRoleRequestValidator()
        {
            RuleFor(request => request.RoleId)
                           .NotEmpty().WithMessage("RoleId is required.");

            RuleFor(request => request.Features)
                           .NotNull().WithMessage("Features is required.");
        }
    }

    public class AssignBulkFeatuersToRoleRequestProfile : Profile
    {
        public AssignBulkFeatuersToRoleRequestProfile()
        {
            CreateMap<AssignBulkFeatuersToRoleRequestViewModel, AssignBulkFeatuersToRoleOrchestrator>();
        }
    }
}
