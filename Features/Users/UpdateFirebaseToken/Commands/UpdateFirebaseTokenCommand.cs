using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Users;

namespace EasyTask.Features.Users.UpdateFirebaseToken.Commands
{
    public record UpdateFirebaseTokenCommand(string ID, string FirebaseToken):IRequestBase<bool>;
    public class UpdateFirebaseTokenCommandHandler : RequestHandlerBase<User, UpdateFirebaseTokenCommand, bool>
    {
        public UpdateFirebaseTokenCommandHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(UpdateFirebaseTokenCommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            User user = new User { ID = request.ID };
            user.Token = request.FirebaseToken;
            _repository.SaveIncluded(user, nameof(user.Token));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
