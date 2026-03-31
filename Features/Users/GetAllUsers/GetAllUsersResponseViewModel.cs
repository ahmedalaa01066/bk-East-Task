using AutoMapper;
using EasyTask.Features.Common.Users.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Users.GetAllUsers
{
    public record GetAllUsersResponseViewModel(string Id, string Name, string Mobile, Role RoleId,bool IsActive);
    public class GetAllUsersResponseProfile : Profile
    {
        public GetAllUsersResponseProfile()
        {
            CreateMap<GetAllUsersDTO,GetAllUsersResponseViewModel >();
        }
    }
}
