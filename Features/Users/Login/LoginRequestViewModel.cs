using AutoMapper;
using EasyTask.Features.Users.Login.Commands;
using EasyTask.Features.Users.Login.Orchestrator;
using FluentValidation;

namespace EasyTask.Features.Users.Login
{
    public record LoginRequestViewModel(
        string Email,
        string Password
    );
    public class LoginRequestValidator : AbstractValidator<LoginRequestViewModel>
    {
        public LoginRequestValidator() { }
    }
    public class LoginRequestProfile : Profile
    {
        public LoginRequestProfile()
        {
            CreateMap<LoginRequestViewModel, LoginOrchestrator>();
            CreateMap<LoginOrchestrator, LoginCommand>();
        }
    }
}
