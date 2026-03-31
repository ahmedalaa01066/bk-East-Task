using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Users;

namespace EasyTask.Features.Users.Login.Commands
{
    public record LoginCommand(string Email, string Password) : IRequestBase<string>;
    public class LoginCommandHandler : RequestHandlerBase<User, LoginCommand, string>
    {
        public LoginCommandHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.Get(c => c.Email == request.Email).FirstOrDefault();

            if ((user == null) || !PasswordHasher.Verify(request.Password, user.Password))
            {
                return RequestResult<string>.Failure(ErrorCode.MobileOrPasswordNotCorrect);
            }
            var token = TokenGenerator.Generate(user.ID, user.Mobile, user.RoleId);

            //var result = new LoginDTO(Token: token, RoleId: user.RoleId);

            return RequestResult<string>.Success(token);
        }

    }
}
