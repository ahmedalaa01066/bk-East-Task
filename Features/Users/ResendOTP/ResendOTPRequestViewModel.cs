using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Users.Queries;
using EasyTask.Features.Users.ResendOTP.Orchestrators;

namespace EasyTask.Features.Users.ResendOTP
{
    public record ResendOTPRequestViewModel(string Token);
    public class ResendOTPRequestValidator:AbstractValidator<ResendOTPRequestViewModel>
    {
        public ResendOTPRequestValidator()
        {

        }
    }
    public class ResendOTPRequestProfile:Profile
    {
        public ResendOTPRequestProfile()
        {
            CreateMap<ResendOTPOrchestrator, CheckTOResendOTPQuery>();
            CreateMap<ResendOTPRequestViewModel, ResendOTPOrchestrator>();

        }
    }
}
