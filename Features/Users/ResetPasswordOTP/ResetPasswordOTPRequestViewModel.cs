using AutoMapper;
using FluentValidation;
using EasyTask.Features.Users.ResetPasswordOTP.Orchestrators;

namespace EasyTask.Features.Users.ResetPasswordOTP
{
    public record ResetPasswordOTPRequestViewModel(string Email);
    public class ResetPasswordOTPRequestValidator : AbstractValidator<ResetPasswordOTPRequestViewModel>
    {
        public ResetPasswordOTPRequestValidator() { }
    }
    public class OTPLoginRequestProfile : Profile
    {
        public OTPLoginRequestProfile()
        {
            CreateMap<ResetPasswordOTPRequestViewModel, ResetPasswordOTPOrchestrator>();
        }
    }
}
