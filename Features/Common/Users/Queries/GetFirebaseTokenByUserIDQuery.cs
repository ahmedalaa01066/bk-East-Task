using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Users.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.Queries
{
    public record GetFirebaseTokenByUserIDQuery(string ID):IRequestBase<string>;
    public class GetFirebaseTokenByUserIDQueryHandler : RequestHandlerBase<User, GetFirebaseTokenByUserIDQuery, string>
    {
        public GetFirebaseTokenByUserIDQueryHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(GetFirebaseTokenByUserIDQuery request, CancellationToken cancellationToken)
        {
            var token = _repository.GetByID(request.ID).Token;

            if (token == null)
                return RequestResult<string>.Failure(ErrorCode.NotFound);
            return RequestResult<string>.Success(token);

        }
    }
}
