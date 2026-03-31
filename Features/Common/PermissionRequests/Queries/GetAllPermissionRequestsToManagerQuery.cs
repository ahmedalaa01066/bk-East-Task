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
    public record GetAllPermissionRequestsToManagerQuery(RequestStatus? Status,int pageIndex = 1, int pageSize = 100) : IRequestBase<PagingViewModel<GetAllPermissionRequestsToManagerDTO>>;
    public class GetAllPermissionRequestsToManagerQueryHandler : RequestHandlerBase<PermissionRequest, GetAllPermissionRequestsToManagerQuery, PagingViewModel<GetAllPermissionRequestsToManagerDTO>>
    {
        public GetAllPermissionRequestsToManagerQueryHandler(RequestHandlerBaseParameters<PermissionRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllPermissionRequestsToManagerDTO>>> Handle(GetAllPermissionRequestsToManagerQuery request, CancellationToken cancellationToken)
        {
            var userId = _userState.UserID;
            var predicate = PredicateExtensions.PredicateExtensions.Begin<PermissionRequest>(true);

            predicate = predicate
                       .And(p => !request.Status.HasValue || p.PermissionRequestStatus == request.Status.Value);

            IQueryable<PermissionRequest> query = _repository.Get(predicate)
                       .Include(c => c.Candidate)
                    .ThenInclude(c => c.Management) 
                .Include(c => c.Permission);

            query = query.Where(r => r.Candidate.Management.ManagerId == userId);

            var requests = await query
                .OrderByDescending(r => r.CreatedDate)
                .Map<GetAllPermissionRequestsToManagerDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllPermissionRequestsToManagerDTO>>.Success(requests);
        }
    }
}
