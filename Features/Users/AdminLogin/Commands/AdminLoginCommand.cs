using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.Users;

namespace EasyTask.Features.Users.AdminLogin.Commands
{
    public record AdminLoginCommand(string Mobile, string Password) : IRequestBase<string>;
    public class AdminLoginCommandHandler : RequestHandlerBase<User, AdminLoginCommand, string>
    {
        public AdminLoginCommandHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(AdminLoginCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.Get(c => c.Mobile == request.Mobile||c.Email==request.Mobile).Where(c=>c.RoleId!=Role.Candidate).FirstOrDefault();

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
