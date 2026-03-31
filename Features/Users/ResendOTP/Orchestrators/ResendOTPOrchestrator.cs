using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Users.GenerateOTP.Commands;
using EasyTask.Features.Common.Users.Queries;
using EasyTask.Features.Common.Users.SendMessage;
using EasyTask.Helpers;
using EasyTask.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EasyTask.Features.Users.ResendOTP.Orchestrators
{
    public record ResendOTPOrchestrator( string Token) : IRequestBase<string>;
    public class ResendOTPOrchestratorHandler : RequestHandlerBase<User, ResendOTPOrchestrator, string>
    {
        public ResendOTPOrchestratorHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(ResendOTPOrchestrator request, CancellationToken cancellationToken)
        {

            var userInfo = await _repository
                  .Get(u => u.OTPtoken == request.Token)
                  .Select(u => new { u.ID, u.Mobile })
                  .FirstOrDefaultAsync();
            if (userInfo != null)
            {
                var OTPresult = await _mediator.Send(new GenerateOTPCommand(userInfo.ID, userInfo.Mobile));
                string Message = "Your New OTP is";
                //var SMSResult = await _mediator.Send(new SendMessageCommand(OTPresult.Data.OTP, userInfo.Mobile, Message));
                return RequestResult<string>.Success(OTPresult.Data.OTPtoken, "Resend OTP successfully.");
            }

            return RequestResult<string>.Failure(ErrorCode.NotFound);
        }
    }
}
