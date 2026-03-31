using AutoMapper;
using EasyTask.Features.Common.Users.DTOs;
using EasyTask.Features.Common.Users.Queries;

namespace EasyTask.Features.Users.GetUserByID
{
    public record GetUserByIDResponseViewModel(string Id, string Name, string Mobile,string Email);
    public class GetUserByIDResponseProfile : Profile
    {
        public GetUserByIDResponseProfile()
        {
            CreateMap<GetUserByIDDTO, GetUserByIDResponseViewModel>();
        }
    }
}
