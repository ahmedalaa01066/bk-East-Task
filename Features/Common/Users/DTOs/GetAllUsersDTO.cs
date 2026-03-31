using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.DTOs
{
    public record GetAllUsersDTO(string Id, string Name, string Mobile,Role RoleId,bool IsActive);
    public class GetAllUsersProfile : Profile
    {
        public GetAllUsersProfile()
        {
            CreateMap<User, GetAllUsersDTO>();
        }
    }
}
