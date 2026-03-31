using AutoMapper;
using EasyTask.Features.Common.PermissionRequests.Queries;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.PermissionRequests.GetAllPermissionRequestsToManager
{
    public record GetAllPermissionRequestsToManagerRequestViewModel(RequestStatus? Status,int pageIndex = 1, int pageSize = 100);
    public class GetAllPermissionRequestsToManagerRequestValidator : AbstractValidator<GetAllPermissionRequestsToManagerRequestViewModel>
    {
        public GetAllPermissionRequestsToManagerRequestValidator()
        {
        }
    }
    public class GetAllPermissionRequestsToManagerRequestProfile : Profile
    {
        public GetAllPermissionRequestsToManagerRequestProfile()
        {
            CreateMap<GetAllPermissionRequestsToManagerRequestViewModel, GetAllPermissionRequestsToManagerQuery>();
        }
    }
}
