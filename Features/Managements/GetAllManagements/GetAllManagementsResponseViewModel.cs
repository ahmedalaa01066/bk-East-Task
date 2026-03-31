using AutoMapper;
using EasyTask.Features.Common.Departments.DTOs;
using EasyTask.Features.Common.Managements.DTOs;
namespace EasyTask.Features.Managements.GetManagementByName
{
    public record GetAllManagementsResponseViewModel(string ID, string Name, bool IsActive, List<DepartmentDTO> Departments ,
        string? ManagerId, string? ManagerName);

    public class GetManagementByNameResponseProfile : Profile
    {
        public GetManagementByNameResponseProfile()
        {
            CreateMap<GetManagementDTO, GetAllManagementsResponseViewModel>();
        }
    }
}
