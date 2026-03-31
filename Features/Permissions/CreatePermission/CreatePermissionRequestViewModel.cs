using AutoMapper;
using EasyTask.Features.Permissions.CreatePermission.Commands;
using FluentValidation;

namespace EasyTask.Features.Permissions.CreatePermission
{
    public record CreatePermissionRequestViewModel(string Name, int MaxHours, int MinHours, int MaxRepeatTimes,
        int MaxHoursPerMonth);
    public class CreatePermissionRequestValidator : AbstractValidator<CreatePermissionRequestViewModel>
    {
        public CreatePermissionRequestValidator()
        {
        }
    }
    public class CreatePermissionRequestProfile : Profile
    {
        public CreatePermissionRequestProfile()
        {
            CreateMap<CreatePermissionRequestViewModel, CreatePermissionCommand>();
        }
    }
}
