using AutoMapper;
using FluentValidation;
using EasyTask.Features.Users.ResetPassword.Commands;

namespace EasyTask.Features.Users.ResetPassword
{
    public record ResetPasswordRequest(string UserID ,string Password,string ConfirmPassword);
    public class ResetPasswordRequestValidtor : AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordRequestValidtor()
        {
        }
    }

    public class ResetPasswordRequestProfile : Profile
    {
        public ResetPasswordRequestProfile()
        {
            CreateMap<ResetPasswordRequest, ResetPasswordCommand>();
        }
    }
}
