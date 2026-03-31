using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.EditUser.Commands
{
    public record EditUserCommand(string ID, string Name, string Mobile, string Email,Role? RoleId) : IRequestBase<bool>;
    public class EditUserCommandHandler : RequestHandlerBase<User, EditUserCommand, bool>
    {
        public EditUserCommandHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            var existingEmails = _repository.Any(c => c.Email == request.Email && c.ID != request.ID);
            if (existingEmails)
            {
                return RequestResult<bool>.Failure(ErrorCode.ExistEmail);
            }

            var phoneValid = _repository.Any(c => c.Mobile == request.Mobile && c.ID != request.ID);
            if (!phoneValid)
            {
                User user = new User { ID = request.ID };
                user.Mobile = request.Mobile;
                user.Name = request.Name;
                user.Email = request.Email;
                user.RoleId = request.RoleId ?? user.RoleId;
                _repository.SaveIncluded(user, nameof(user.Name), nameof(user.RoleId), nameof(user.Mobile), nameof(user.Email));

                _repository.SaveChanges();
                return RequestResult<bool>.Success(true);
            }
            else
            {
                return await Task.FromResult(RequestResult<bool>.Failure(ErrorCode.ExistMobile));
            }

        }
    }
}
