using AutoMapper;
using EasyTask.Features.Common.PermissionRequests.Queries;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.PermissionRequests.GetAllPermissionRequests
{
    public record GetAllPermissionRequestsRequestViewModel(RequestStatus? Status,int pageIndex = 1, int pageSize = 100);
    public class GetAllPermissionRequestsRequestValidator : AbstractValidator<GetAllPermissionRequestsRequestViewModel>
    {
        public GetAllPermissionRequestsRequestValidator()
        {
        }
    }
    public class GetAllPermissionRequestsRequestProfile : Profile
    {
        public GetAllPermissionRequestsRequestProfile()
        {
            CreateMap<GetAllPermissionRequestsRequestViewModel, GetAllPermissionRequestsQuery>();
        }
    }
}
