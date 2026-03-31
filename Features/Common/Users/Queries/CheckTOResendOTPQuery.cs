using EasyTask.Common.Requests;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.Queries
{
    public record CheckTOResendOTPQuery(string Mobile,string Token):IRequestBase<string>;
    public class CheckTOResendOTPQueryHandler : RequestHandlerBase<User, CheckTOResendOTPQuery, string>
    {
        public CheckTOResendOTPQueryHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CheckTOResendOTPQuery request, CancellationToken cancellationToken)
        {
            var UserId =  _repository.Get(u=>u.Mobile==request.Mobile&&u.OTPtoken==request.Token).Select(u=>u.ID).FirstOrDefault();
            return RequestResult<string>.Success(UserId);
        }
    }


}
