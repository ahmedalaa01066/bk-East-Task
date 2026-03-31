using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.Managements;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Managements.Queries
{
    public record SelectManagementListQuery(string? JobId) :IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class SelectManagementListQueryHandler : RequestHandlerBase<Management, SelectManagementListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public SelectManagementListQueryHandler(RequestHandlerBaseParameters<Management> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(SelectManagementListQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Management>(true);

            if (!string.IsNullOrEmpty(request.JobId))
            {
                predicate = predicate.And(m => m.Jobs.Any(j => j.ID == request.JobId));
            }

            var selectListItems = _repository
                .Get(predicate)
                .ToSelectListViewModel();

            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);
        }

    }
}
