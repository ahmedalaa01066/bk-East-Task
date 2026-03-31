using AutoMapper;
using EasyTask.Features.Common.Departments.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Departments.SelectDepartmentListByManagementIds
{
    public record SelectDepartmentListByManagementIdsResponseViewModel(string ID, string Name, Assignment Assignment);
    public class SelectDepartmentListByManagementIdsResponseProfile : Profile
    {
        public SelectDepartmentListByManagementIdsResponseProfile()
        {
            CreateMap<SelectDepartmentListByManagementIdsDTO, SelectDepartmentListByManagementIdsResponseViewModel>();
        }
    }
}
