using EasyTask.Common.Requests;
using EasyTask.Features.Common.Users.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.Queries
{
    
    public record GetUserByIDQuery(string ID) : IRequestBase<GetUserByIDDTO>;
    public class GetUserByIDQueryHandler : RequestHandlerBase<User, GetUserByIDQuery, GetUserByIDDTO>
    {
        public GetUserByIDQueryHandler(RequestHandlerBaseParameters<User> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<GetUserByIDDTO>> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {

            var user = _repository.GetByID(request.ID).MapOne<GetUserByIDDTO>();

            if (user == null)
                return RequestResult<GetUserByIDDTO>.Failure();

            return RequestResult<GetUserByIDDTO>.Success(user);
        }
    }
}
