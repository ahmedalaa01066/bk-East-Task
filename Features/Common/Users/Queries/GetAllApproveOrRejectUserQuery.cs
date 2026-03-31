using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Users.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.Queries
{
    public record GetAllVerifiedOrRejectUserQuery(int PageIndex=1,int PageSize=100) :IRequestBase<PagingViewModel<VerifiedStatusDTO>>;
    public class GetAllVerifiedOrRejectUserQueryHandler : RequestHandlerBase<User, GetAllVerifiedOrRejectUserQuery, PagingViewModel<VerifiedStatusDTO>>
    {
        public GetAllVerifiedOrRejectUserQueryHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<VerifiedStatusDTO>>> Handle(GetAllVerifiedOrRejectUserQuery request, CancellationToken cancellationToken)
        {
            var users =await _repository.Get(u => u.VerifyStatus == VerifyStatus.Verified).Map<VerifiedStatusDTO>()
                .ToPagesAsync(request.PageIndex, request.PageSize);
            return RequestResult<PagingViewModel<VerifiedStatusDTO>>.Success(users);
        }
    }
}
