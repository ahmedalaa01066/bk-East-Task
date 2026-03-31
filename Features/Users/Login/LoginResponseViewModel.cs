using AutoMapper;

namespace EasyTask.Features.Users.Login
{
    public record LoginResponseViewModel(string Token, string AttendanceId);
    public record LoginResponseDTO(string Token, string AttendanceId);

    public class LoginResponseProfile : Profile
    {
        public LoginResponseProfile()
        {
            CreateMap<LoginResponseDTO, LoginResponseViewModel>();
        }
    }
}
