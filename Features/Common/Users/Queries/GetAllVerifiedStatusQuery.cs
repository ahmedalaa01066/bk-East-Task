using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Users.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.Queries
{
    public record GetAllVerifiedStatusQuery(int pageIndex = 1, int pageSize = 100) :IRequestBase<PagingViewModel<VerifiedStatusDTO>>;
    public class GetAllVerifiedStatusQueryHandler : RequestHandlerBase<User, GetAllVerifiedStatusQuery, PagingViewModel<VerifiedStatusDTO>>
    {
        public GetAllVerifiedStatusQueryHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<VerifiedStatusDTO>>> Handle(GetAllVerifiedStatusQuery request, CancellationToken cancellationToken)
        {
            var users=await _repository.Get(u=>u.VerifyStatus==VerifyStatus.Verified)
                .Map<VerifiedStatusDTO>().
                ToPagesAsync(request.pageIndex, request.pageSize); ;
            return RequestResult<PagingViewModel<VerifiedStatusDTO>>.Success(users);
        }
    }
}
