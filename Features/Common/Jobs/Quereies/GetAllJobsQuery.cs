using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Helpers;
using EasyTask.Models.Jobs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Jobs.DTOs
{
    public record GetAllJobsQuery(string? SearchText, int pageIndex = 1, int pageSize = 100) : IRequestBase<PagingViewModel<GetAllJobsDTO>>;
    public class GetAllJobsQueryHandler : RequestHandlerBase<Job, GetAllJobsQuery, PagingViewModel<GetAllJobsDTO>>
    {
        public GetAllJobsQueryHandler(RequestHandlerBaseParameters<Job> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllJobsDTO>>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Job>(true);

            if (!string.IsNullOrEmpty(request.SearchText))
            {
                predicate = predicate.And(c =>
                    c.Name.Contains(request.SearchText) ||
                    c.JobCode.Contains(request.SearchText) ||
                    c.Management.Name.Contains(request.SearchText));
            }

            var query = await _repository
                .Get(predicate).Include(c=>c.Management)
                 .Map<GetAllJobsDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllJobsDTO>>.Success(query);
        }
    }
}
