using AutoMapper;
using EasyTask.Features.Common.Departments.DTOs;
using EasyTask.Models.Departments;
using EasyTask.Models.Managements;

namespace EasyTask.Features.Common.Managements.DTOs
{
    public class GetManagementDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<DepartmentDTO> Departments { get; set; }
        public string? ManagerId { get; set; }
        public string? ManagerName { get; set; }
    }
    public class GetManagementByNameProfile : Profile
    {
        public GetManagementByNameProfile()
        {
            CreateMap<Management, GetManagementDTO>()
             .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.Departments))
             .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
             .ForMember(
                 dest => dest.ManagerName,
                 opt => opt.MapFrom(src =>
                     src.Manager != null
                         ? $"{src.Manager.FirstName} {src.Manager.LastName}"
                         : null
                 )
             );
            CreateMap<Department, DepartmentDTO>();
        }
    }
}
