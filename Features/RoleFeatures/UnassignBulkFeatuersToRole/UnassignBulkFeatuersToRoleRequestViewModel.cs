using AutoMapper;
using FluentValidation;
using EasyTask.Features.RoleFeatures.UnassignBulkFeaturesFromRole.Commands;
using EasyTask.Models.Enums;

namespace EasyTask.Features.RoleFeatures.UnassignBulkFeatuersToRole
{
    public record UnassignBulkFeatuersToRoleRequestViewModel(Role RoleId, IEnumerable<Feature> Features);
    public class UnassignBulkFeatuersToRoleRequestValidator : AbstractValidator<UnassignBulkFeatuersToRoleRequestViewModel>
    {
        public UnassignBulkFeatuersToRoleRequestValidator()
        {
        }
    }
    public class UnassignBulkFeatuersToRoleRequestProfile : Profile
    {
        public UnassignBulkFeatuersToRoleRequestProfile()
        {
            CreateMap<UnassignBulkFeatuersToRoleRequestViewModel, UnassignBulkFeaturesFromRoleCommand>();
        }
    }
}
