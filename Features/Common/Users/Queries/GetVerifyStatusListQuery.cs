using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.Users;

namespace EasyTask.Features.Users.GetVerifyStatusList.Queries
{
    public record GetVerifyStatusListQuery() : IRequestBase<List<SelectListItemViewModel>>;
    public class GetVerifyStatusListQueryHandler : RequestHandlerBase<User, GetVerifyStatusListQuery, List<SelectListItemViewModel>>
    {
        public GetVerifyStatusListQueryHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<SelectListItemViewModel>>> Handle(GetVerifyStatusListQuery request, CancellationToken cancellationToken)
        {
            var verifyStatusList = EnumHelper.ToSelectableList<VerifyStatus>();

            return RequestResult<List<SelectListItemViewModel>>.Success(verifyStatusList);
        }
    }
}