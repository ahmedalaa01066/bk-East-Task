using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.CreateUser.Commands
{
    public record CreateUserCommand(string Name, string Email, string Password, string ConfirmPassword, string Mobile, Role RoleId, VerifyStatus VerifyStatus) : IRequestBase<string>;
    public class CreateUserCommandHandler : RequestHandlerBase<User, CreateUserCommand, string>
    {
        public CreateUserCommandHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var existingEmails = _repository.Any(c => c.Email == request.Email);
            if (existingEmails)
            {
                return RequestResult<string>.Failure(ErrorCode.ExistEmail);
            }

            var phoneValid = _repository.Get(c => c.Mobile == request.Mobile).FirstOrDefault();
            if (phoneValid == null)
            {
                var password = PasswordHasher.Hash(request.Password);

                User user = new User
                {
                    Name = request.Name,
                    Password = password,
                    Email = request.Email,
                    RoleId = request.RoleId,
                    Mobile = request.Mobile,
                    IsActive = true,
                    VerifyStatus = request.VerifyStatus
                };

                _repository.Add(user);
                _repository.SaveChanges();
                var UserId = user.ID;
                var result = RequestResult<string>.Success(UserId);

                return await Task.FromResult(result);
            }
            return RequestResult<string>.Failure(ErrorCode.ExistMobile);
        }
    }
}
