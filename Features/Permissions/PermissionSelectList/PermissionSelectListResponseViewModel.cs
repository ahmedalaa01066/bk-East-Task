using AutoMapper;
using EasyTask.Common.Views;

namespace EasyTask.Features.Permissions.PermissionSelectList
{
    public record PermissionSelectListResponseViewModel(string Name, string ID);
    public class PermissionSelectListResponseProfile : Profile
    {
        public PermissionSelectListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, PermissionSelectListResponseViewModel>();
        }
    }
}
