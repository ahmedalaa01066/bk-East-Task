using AutoMapper;
using EasyTask.Models.Permissions;

namespace EasyTask.Features.Common.Permissions.DTOs
{
    public class GetPermissionByIdDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int MaxHours { get; set; }
        public int MinHours { get; set; }
        public int MaxRepeatTimes { get; set; }
        public int MaxHoursPerMonth { get; set; }
    }
    public class GetPermissionByIdDTOProfile : Profile
    {
        public GetPermissionByIdDTOProfile()
        {
            CreateMap<Permission, GetPermissionByIdDTO>();
        }
    }
}
