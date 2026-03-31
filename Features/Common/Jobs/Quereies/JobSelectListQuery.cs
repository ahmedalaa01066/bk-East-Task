using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Models.Jobs;
using Microsoft.IdentityModel.Tokens;

namespace EasyTask.Features.Common.Jobs.Quereies
{
    public record JobSelectListQuery(string? ManagementId) : IRequestBase<IEnumerable<SelectListItemViewModel>>;
    public class JobSelectListQueryHandler : RequestHandlerBase<Job, JobSelectListQuery, IEnumerable<SelectListItemViewModel>>
    {
        public JobSelectListQueryHandler(RequestHandlerBaseParameters<Job> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectListItemViewModel>>> Handle(JobSelectListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = _repository.Get(j => j.ManagementId == request.ManagementId).ToSelectListViewModel();
            if (request.ManagementId.IsNullOrEmpty())
                selectListItems = _repository.Get().ToSelectListViewModel();
            return RequestResult<IEnumerable<SelectListItemViewModel>>.Success(selectListItems);
        }
    }
}
