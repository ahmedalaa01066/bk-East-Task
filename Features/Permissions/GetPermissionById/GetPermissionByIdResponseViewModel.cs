using AutoMapper;
using EasyTask.Features.Common.Permissions.DTOs;

namespace EasyTask.Features.Permissions.GetPermissionById
{
    public class GetPermissionByIdResponseViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int MaxHours { get; set; }
        public int MinHours { get; set; }
        public int MaxRepeatTimes { get; set; }
        public int MaxHoursPerMonth { get; set; }
    }
    public class GetPermissionByIdResponseProfile : Profile
    {
        public GetPermissionByIdResponseProfile()
        {
            CreateMap<GetPermissionByIdDTO, GetPermissionByIdResponseViewModel>();
        }
    }
}
