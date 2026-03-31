using AutoMapper;
using EasyTask.Features.PermissionRequests.FirstApprovePermissionRequest.Commands;
using FluentValidation;

namespace EasyTask.Features.PermissionRequests.FirstApprovePermissionRequest
{
    public record FirstApprovePermissionRequestRequestViewModel(string ID);
    public class FirstApprovePermissionRequestRequestValidator : AbstractValidator<FirstApprovePermissionRequestRequestViewModel>
    {
        public FirstApprovePermissionRequestRequestValidator()
        {
        }
    }
    public class FirstApprovePermissionRequestRequestProfile : Profile
    {
        public FirstApprovePermissionRequestRequestProfile()
        {
            CreateMap<FirstApprovePermissionRequestRequestViewModel, FirstApprovePermissionRequestCommand>();
        }
    }
}
