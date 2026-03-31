using AutoMapper;
using EasyTask.Common.Views;

namespace EasyTask.Features.WorkPackages.WorkPackageSelectList
{
    public record WorkPackageSelectListResponseViewModel(string Name, string ID);
    public class WorkPackageSelectListResponseProfile : Profile
    {
        public WorkPackageSelectListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, WorkPackageSelectListResponseViewModel>();
        }
    }
}
