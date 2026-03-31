using AutoMapper;
using EasyTask.Features.PermissionRequests.RejectPermissionRequest.Commands;
using FluentValidation;

namespace EasyTask.Features.PermissionRequests.RejectPermissionRequest
{
    public record RejectPermissionRequestRequestViewModel(string ID);
    public class RejectPermissionRequestRequestValidator : AbstractValidator<RejectPermissionRequestRequestViewModel>
    {
        public RejectPermissionRequestRequestValidator()
        {
        }
    }
    public class RejectPermissionRequestRequestProfile : Profile
    {
        public RejectPermissionRequestRequestProfile()
        {
            CreateMap<RejectPermissionRequestRequestViewModel, RejectPermissionRequestCommand>();
        }
    }
}
