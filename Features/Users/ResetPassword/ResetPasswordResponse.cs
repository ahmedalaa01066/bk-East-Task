using AutoMapper;

namespace EasyTask.Features.Users.ResetPassword
{
    public record ResetPasswordResponse(string Token);
    public class ResetPasswordResponseProfile : Profile
    {
        public ResetPasswordResponseProfile()
        {
            CreateMap<string, ResetPasswordResponse>();
        }
    }
}
