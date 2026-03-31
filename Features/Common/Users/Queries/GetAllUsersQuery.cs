using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Users.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.Users;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Users.Queries
{
    public record GetAllUsersQuery(string? Mobile, int pageIndex = 1,
        int pageSize = 100) :IRequestBase<PagingViewModel<GetAllUsersDTO>>;
    public class GetAllUsersQueryHandler : RequestHandlerBase<User, GetAllUsersQuery, PagingViewModel<GetAllUsersDTO>>
    {
        public GetAllUsersQueryHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllUsersDTO>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<User>(true);

            predicate = predicate
                .And(c => string.IsNullOrEmpty(request.Mobile) || c.Mobile.Contains(request.Mobile))
                .And(c => c.RoleId != Role.Candidate); 
            ;
            var query = await _repository.Get(predicate).Map<GetAllUsersDTO>().ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllUsersDTO>>.Success(query);

        }
    }
}
