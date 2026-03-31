using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Users.Queries
{
    public record CheckOTPValidationQuery(string Token, string OTP) : IRequestBase<string>;
    public class CheckOTPValidationQueryHandler : RequestHandlerBase<User, CheckOTPValidationQuery, string>
    {
        public CheckOTPValidationQueryHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CheckOTPValidationQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.Get(u => u.OTP == request.OTP && u.OTPtoken == request.Token).FirstOrDefaultAsync();
            if (user != null)
            {
                if (user.OTPExpiration >= DateTime.Now)
                {
                    return RequestResult<string>.Success(user.ID);
                }
            }
            return RequestResult<string>.Failure(ErrorCode.InvalidOTP);

        }
    }

}
