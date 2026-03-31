using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.SendMessage
{
    public record SendMessageCommand(string OTP,string Mobile,string Message):IRequestBase<bool>;
    public class SendMessageCommandHandler : RequestHandlerBase<User, SendMessageCommand, bool>
    {
        public SendMessageCommandHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var smsResponse = await SMSHelper.SendSmsAsync(request.Mobile, request.Message+request.OTP);
             
            if (!smsResponse.Success)
                return RequestResult<bool>.Failure(ErrorCode.CannotSend);
            return RequestResult<bool>.Success(true);
        }
    }
}
