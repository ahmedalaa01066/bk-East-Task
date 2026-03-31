using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.PermissionRequests.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.PermissionRequests;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.PermissionRequests.Queries
{
    public record GetAllPermissionRequestsQuery(RequestStatus? Status,int pageIndex = 1, int pageSize = 100) : IRequestBase<PagingViewModel<GetAllPermissionRequestsDTO>>;
    public class GetAllPermissionRequestsQueryHandler : RequestHandlerBase<PermissionRequest, GetAllPermissionRequestsQuery, PagingViewModel<GetAllPermissionRequestsDTO>>
    {
        public GetAllPermissionRequestsQueryHandler(RequestHandlerBaseParameters<PermissionRequest> requestParameters) : base(requestParameters)
        {
        }
        public async override Task<RequestResult<PagingViewModel<GetAllPermissionRequestsDTO>>> Handle(GetAllPermissionRequestsQuery request, CancellationToken cancellationToken)
        {
            var roleId = _userState.RoleID;
            var userId = _userState.UserID;
            var predicate = PredicateExtensions.PredicateExtensions.Begin<PermissionRequest>(true);

            predicate = predicate
                .And(p => !request.Status.HasValue || p.PermissionRequestStatus == request.Status.Value);

            IQueryable<PermissionRequest> query = _repository.Get(predicate)
                .Include(c => c.Candidate)
                 .ThenInclude(c => c.Management)
                .Include(c => c.Permission);
            if (roleId == Role.Candidate)
            {
                query = query.Where(r => r.CandidateId == userId);
            }
            if (roleId == Role.Manager)
            {
                query = query.Where(r => r.Candidate.Management.ManagerId == userId);
            }
            var requests = await query
                .OrderByDescending(r => r.CreatedDate)
                .Map<GetAllPermissionRequestsDTO>()   
                .ToPagesAsync(request.pageIndex, request.pageSize); 

            return RequestResult<PagingViewModel<GetAllPermissionRequestsDTO>>.Success(requests);
        }


    }
}
