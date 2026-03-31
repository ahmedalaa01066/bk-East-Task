using AutoMapper;
using EasyTask.Features.PermissionRequests.CancelPermissionRequest.Commands;
using FluentValidation;

namespace EasyTask.Features.PermissionRequests.CancelPermissionRequest
{
    public record CancelPermissionRequestRequestViewModel(string ID);
    public class CancelPermissionRequestRequestValidator : AbstractValidator<CancelPermissionRequestRequestViewModel>
    {
        public CancelPermissionRequestRequestValidator()
        {
        }
    }
    public class CancelPermissionRequestRequestProfile : Profile
    {
        public CancelPermissionRequestRequestProfile()
        {
            CreateMap<CancelPermissionRequestRequestViewModel, CancelPermissionRequestCommand>();
        }
    }
}
