using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.DTOs
{
    public record LoginDTO(string Token,Role RoleId);
    public class LoginDTOProfile : Profile
    {
        public LoginDTOProfile() {
            CreateMap<User, LoginDTO>();
        }
    }
}
