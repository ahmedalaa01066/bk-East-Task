using Microsoft.AspNetCore.Mvc;
using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Users.GenerateOTP.Commands;
using EasyTask.Features.Common.Users.Queries;
using EasyTask.Features.Emails.SendEmailToClients.Commands;
using EasyTask.Models.Enums;
using EasyTask.Models.Users;

namespace EasyTask.Features.Users.ResetPasswordOTP.Orchestrators
{
    public record ResetPasswordOTPOrchestrator(string Email) : IRequestBase<string>;
    public class ResetPasswordOTPHandler : RequestHandlerBase<User, ResetPasswordOTPOrchestrator, string>
    {
        public ResetPasswordOTPHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(ResetPasswordOTPOrchestrator request, CancellationToken cancellationToken)
        {
            var user = _repository.Get(c => c.Email == request.Email).FirstOrDefault();
            if (user != null)
            {
                var IsVerifiedd = await _repository.AnyAsync(c => c.VerifyStatus == VerifyStatus.Verified && c.ID == user.ID);
                if (IsVerifiedd)
                {
                    var IsActiveClient = await _mediator.Send(new CheckUserActivationQuery(user.ID));
                    if (IsActiveClient.Data)
                    {
                        string Message = "Your OTP for Login is";
                        var OTPresult = await _mediator.Send(new GenerateOTPCommand(user.ID, user.Mobile));

                        var subject = "EasyTask - Email Verification Code";
                        var body = $@"Welcome to EasyTask!<br/><br/>
                               Your verification code is: <strong>{OTPresult.Data.OTP}</strong><br/><br/>
                               Please enter this code in the app to verify your email address and proceed with your password reset.<br/><br/>
                               If you did not request this, you can safely ignore this email.<br/><br/>
                               Thank you,<br/>
                               EasyTask Team";

                        var SendEmail = await _mediator.Send(new SendEmailToClientsCommand(new List<string> { request.Email },subject,body));

                        return RequestResult<string>.Success(OTPresult.Data.OTPtoken, "OTP Generated successfully.");
                    }
                    return RequestResult<string>.Failure(ErrorCode.NotActive);
                }
                return RequestResult<string>.Failure(ErrorCode.NotVerified);
            }
            return RequestResult<string>.Failure(ErrorCode.NoAccountForEmail);
        }
    }
}
