using AutoMapper;
using EasyTask.Features.Common.PermissionRequests.Queries;
using FluentValidation;

namespace EasyTask.Features.PermissionRequests.GetByIdPermissionRequest
{
    public record GetPermissionRequestByIdRequestViewModel(string ID);
    public class GetPermissionRequestByIdRequestValidator : AbstractValidator<GetPermissionRequestByIdRequestViewModel>
    {
        public GetPermissionRequestByIdRequestValidator()
        {
        }
    }
    public class GetPermissionRequestByIdRequestProfile : Profile
    {
        public GetPermissionRequestByIdRequestProfile()
        {
            CreateMap<GetPermissionRequestByIdRequestViewModel, GetPermissionRequestByIdQuery>();
        }
    }
}
