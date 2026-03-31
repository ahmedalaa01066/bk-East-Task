using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.ExternalMembers;
using Microsoft.IdentityModel.Tokens;

namespace EasyTask.Features.Common.ExternalMembers.Queries
{
    public record ExternalMemberSelectListQuery(string? Name):IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class ExternalMemberSelectListQueryHandler : RequestHandlerBase<ExternalMember, ExternalMemberSelectListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public ExternalMemberSelectListQueryHandler(RequestHandlerBaseParameters<ExternalMember> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(ExternalMemberSelectListQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Get();

            if (!request.Name.IsNullOrEmpty())
                query = query.Where(e => e.Name.Contains(request.Name));


            var selectListItems =  query.ToSelectListViewModel();

            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);

        }
    }
}
