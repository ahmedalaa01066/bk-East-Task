using AutoMapper;
using EasyTask.Features.Common.Users.Queries;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.DTOs
{
    public record GetUserByIDDTO(string Id, string Name, string Mobile, string Email);
    public class GetUserByIDDTOProfile : Profile
    {
        public GetUserByIDDTOProfile()
        {
            CreateMap<User, GetUserByIDDTO>();
            CreateMap<GetUserByIDDTO, GetUserByIDQuery>();
        }
    }
}
