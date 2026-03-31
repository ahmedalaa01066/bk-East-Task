using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Medias.Queries;
using EasyTask.Features.Common.Users.DTOs;
using EasyTask.Models.Enums;
using EasyTask.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Users.Queries
{
    public record UserDataQuery() : IRequestBase<UserDataDTO>;

    public class UserDataQueryHandler : RequestHandlerBase<User, UserDataQuery, UserDataDTO>
    {
        public UserDataQueryHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<UserDataDTO>> Handle(UserDataQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.Get(u => u.ID == _userState.UserID)
                .Select(u => new UserDataDTO(
                    u.ID,
                    u.Name,
                    u.Mobile,
                    u.Email,
                    null
                ))
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return RequestResult<UserDataDTO>.Failure(ErrorCode.Unauthorize);
            }

            var mediaResult = await _mediator.Send(new GetMediaForAnySourceQuery(user.ID, SourceType.CandidateImage));

            return RequestResult<UserDataDTO>.Success(new UserDataDTO(
                user.ID,
                user.Name,
                user.Phone,
                user.Email,
                mediaResult.IsSuccess ? mediaResult.Data : string.Empty
            ));
        }

    }
}
