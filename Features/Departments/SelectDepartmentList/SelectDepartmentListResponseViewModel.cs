using AutoMapper;
using EasyTask.Common.Views;

namespace EasyTask.Features.Departments.SelectDepartmentList
{
    public record SelectDepartmentListResponseViewModel(string ID, string Name);
    public class SelectDepartmentListResponseProfile : Profile
    {
        public SelectDepartmentListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, SelectDepartmentListResponseViewModel>();
        }
    }
}
