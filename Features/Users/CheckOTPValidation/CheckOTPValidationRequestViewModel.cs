using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Users.Queries;

namespace EasyTask.Features.Users.CheckOTPValidation
{
    public record CheckOTPValidationRequestViewModel(string Token, string OTP);
    public class CheckOTPValidationRequestVaildator : AbstractValidator<CheckOTPValidationRequestViewModel>
    {
        public CheckOTPValidationRequestVaildator()
        {

        }
    }
    public class CheckOTPValidationRequestProfile : Profile
    {
        public CheckOTPValidationRequestProfile()
        {
            CreateMap<CheckOTPValidationRequestViewModel, CheckOTPValidationQuery>();
            //CreateMap<LoginOrchestrator, CheckOTPValidationQuery>();

        }
    }
}
