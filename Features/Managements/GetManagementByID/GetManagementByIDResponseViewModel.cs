using AutoMapper;
using EasyTask.Features.Common.Departments.DTOs;
using EasyTask.Features.Common.Managements.DTOs;

namespace EasyTask.Features.Managements.GetManagementByID
{
    public record GetManagementByIDResponseViewModel(string ID, string Name, bool IsActive, List<DepartmentDTO> Departments, string? ManagerId
        , string? ManagerName);

    public class GetManagementByIDResponseProfile:Profile
    {
        public GetManagementByIDResponseProfile()
        {
            CreateMap<GetManagementDTO, GetManagementByIDResponseViewModel>();
        }
    }
}
