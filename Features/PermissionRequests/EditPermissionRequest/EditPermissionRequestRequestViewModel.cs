using AutoMapper;
using EasyTask.Features.PermissionRequests.EditPermissionRequest.Commands;
using FluentValidation;

namespace EasyTask.Features.PermissionRequests.EditPermissionRequest
{
    public record EditPermissionRequestRequestViewModel(string ID, string PermissionId, DateOnly Date,
        TimeSpan FromTime, TimeSpan ToTime);
    public class EditPermissionRequestRequestValidator : AbstractValidator<EditPermissionRequestRequestViewModel>
    {
        public EditPermissionRequestRequestValidator()
        {
        }
    }
    public class EditPermissionRequestRequestProfile : Profile
    {
        public EditPermissionRequestRequestProfile()
        {
            CreateMap<EditPermissionRequestRequestViewModel, EditPermissionRequestCommand>();
        }
    }
}
