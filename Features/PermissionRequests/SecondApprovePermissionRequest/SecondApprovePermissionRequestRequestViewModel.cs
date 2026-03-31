using AutoMapper;
using EasyTask.Features.PermissionRequests.SecondApprovePermissionRequest.Commands;
using EasyTask.Features.PermissionRequests.SecondApprovePermissionRequest.Orchestrator;
using FluentValidation;

namespace EasyTask.Features.PermissionRequests.SecondApprovePermissionRequest
{
    public record SecondApprovePermissionRequestRequestViewModel(string ID);
    public class SecondApprovePermissionRequestRequestValidator : AbstractValidator<SecondApprovePermissionRequestRequestViewModel>
    {
        public SecondApprovePermissionRequestRequestValidator()
        {
        }
    }
    public class SecondApprovePermissionRequestRequestProfile : Profile
    {
        public SecondApprovePermissionRequestRequestProfile()
        {
            CreateMap<SecondApprovePermissionRequestRequestViewModel, SecondApprovePermissionRequestOrchestrator>();
            CreateMap<SecondApprovePermissionRequestOrchestrator, SecondApprovePermissionRequestCommand>();
        }
    }
}
