using AutoMapper;
using EasyTask.Features.Common.Permissions.Queries;
using FluentValidation;

namespace EasyTask.Features.Permissions.PermissionSelectList
{
    public record PermissionSelectListRequestViewModel();
    public class PermissionSelectListRequestValidator : AbstractValidator<PermissionSelectListRequestViewModel>
    {
        public PermissionSelectListRequestValidator()
        {
        }
    }
    public class PermissionSelectListRequestProfile : Profile
    {
        public PermissionSelectListRequestProfile()
        {
            CreateMap<PermissionSelectListRequestViewModel, PermissionSelectListQuery>();
        }
    }
}
