using AutoMapper;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.DTOs
{
    public record OTPDTO(string OTP,string OTPtoken);
    public class OTPProfile : Profile
    {
        public OTPProfile() 
        {
            CreateMap<User, OTPDTO>();
        }
    }
}
