using AutoMapper;

namespace EasyTask.Features.Users.AdminLogin
{
    public record AdminLoginResponseViewModel(string Token);
    public class LoginResponseProfile : Profile
    {
        public LoginResponseProfile()
        {
            CreateMap<string, AdminLoginResponseViewModel>()
            .ConstructUsing(Token => new AdminLoginResponseViewModel(Token));
        }
    }
}
