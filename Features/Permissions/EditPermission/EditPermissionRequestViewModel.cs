using AutoMapper;
using EasyTask.Features.Permissions.EditPermission.Commands;
using FluentValidation;

namespace EasyTask.Features.Permissions.EditPermission
{
    public record EditPermissionRequestViewModel(string ID, string Name, int MaxHours, int MinHours,
        int MaxRepeatTimes, int MaxHoursPerMonth);
    public class EditPermissionRequestValidator : AbstractValidator<EditPermissionRequestViewModel>
    {
        public EditPermissionRequestValidator()
        {
        }
    }
    public class EditPermissionRequestProfile : Profile
    {
        public EditPermissionRequestProfile()
        {
            CreateMap<EditPermissionRequestViewModel, EditPermissionCommand>();
        }
    }
}
