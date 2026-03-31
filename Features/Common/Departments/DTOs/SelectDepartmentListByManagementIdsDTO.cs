using AutoMapper;
using EasyTask.Models.Departments;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.Departments.DTOs
{
    public class SelectDepartmentListByManagementIdsDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Assignment Assignment { get; set; }
    }
    public class SelectDepartmentListByManagementIdsDTOProfile : Profile
    {
        public SelectDepartmentListByManagementIdsDTOProfile()
        {
            CreateMap<Department, SelectDepartmentListByManagementIdsDTO>();
        }
    }
}
