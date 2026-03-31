using AutoMapper;
using EasyTask.Features.Common.Permissions.Queries;
using FluentValidation;

namespace EasyTask.Features.Permissions.GetByIdPermission
{
    public record GetPermissionByIdRequestViewModel(string ID);
    public class GetPermissionByIdRequestValidator : AbstractValidator<GetPermissionByIdRequestViewModel>
    {
        public GetPermissionByIdRequestValidator()
        {
        }
    }
    public class GetPermissionByIdRequestProfile : Profile
    {
        public GetPermissionByIdRequestProfile()
        {
            CreateMap<GetPermissionByIdRequestViewModel, GetPermissionByIdQuery>();
        }
    }
}
