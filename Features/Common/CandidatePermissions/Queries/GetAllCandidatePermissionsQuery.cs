using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.CandidatePermissions.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.CandidatePermissions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.CandidatePermissions.Queries
{
    public record GetAllCandidatePermissionsQuery(
        string? SearchText, 
        int pageIndex = 1,
        int pageSize = 100
    ):IRequestBase<PagingViewModel<GetAllCandidatePermissionsDTO>>;
    public class GetAllCandidatePermissionsQueryHandler : RequestHandlerBase<CandidatePermission, GetAllCandidatePermissionsQuery, PagingViewModel<GetAllCandidatePermissionsDTO>>
    {
        public GetAllCandidatePermissionsQueryHandler(RequestHandlerBaseParameters<CandidatePermission> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllCandidatePermissionsDTO>>> Handle(GetAllCandidatePermissionsQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<CandidatePermission>(true);

            predicate = predicate.And(c =>
                string.IsNullOrEmpty(request.SearchText) ||
                (c.Candidate.FirstName + " " + c.Candidate.LastName).Contains(request.SearchText) ||
                c.Permission.Name.Contains(request.SearchText));

            var result = await _repository
                .Get(predicate)
                .Include(c => c.Candidate)
                .Include(c => c.Permission)
                .OrderByDescending(c => c.PermissionMonth)
                .Map<GetAllCandidatePermissionsDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllCandidatePermissionsDTO>>.Success(result);
        }
    }
}
