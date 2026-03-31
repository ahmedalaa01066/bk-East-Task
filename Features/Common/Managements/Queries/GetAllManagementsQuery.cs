using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Managements.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Managements;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Managements.Queries
{
    public record GetAllManagementsQuery(string? Name, int pageIndex = 1,
        int pageSize = 100):IRequestBase<PagingViewModel<GetManagementDTO>>;
    public class GetManagementByNameQueryHandler : RequestHandlerBase<Management, GetAllManagementsQuery, PagingViewModel<GetManagementDTO>>
    {
        public GetManagementByNameQueryHandler(RequestHandlerBaseParameters<Management> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetManagementDTO>>> Handle(GetAllManagementsQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Management>(true);

            predicate = predicate
                .And(c => string.IsNullOrEmpty(request.Name) ? true : c.Name.Contains(request.Name));
            var query = await _repository
                .Get(predicate)
                .Include(c => c.Departments)
                .ThenInclude(d => d.Candidates)
                .Map<GetManagementDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);
            return RequestResult<PagingViewModel<GetManagementDTO>>.Success(query);
        }
    }
}
