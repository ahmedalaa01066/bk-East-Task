using AutoMapper;
using FluentValidation;
using EasyTask.Features.Users.AdminLogin.Commands;

namespace EasyTask.Features.Users.AdminLogin
{
    public record AdminLoginRequestViewModel(
        string Mobile,
        string Password
    
    );
    public class LoginRequestValidator : AbstractValidator<AdminLoginRequestViewModel>
    {
        public LoginRequestValidator() { }
    }
    public class LoginRequestProfile : Profile
    {
        public LoginRequestProfile()
        {
            CreateMap<AdminLoginRequestViewModel, AdminLoginCommand>();
        }
    }
}
