using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.PermissionRequests.DTOs;
using EasyTask.Features.Common.VacationRequests.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.PermissionRequests;
using EasyTask.Models.VacationRequests;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.VacationRequests.Queries
{
    public record GetAllVacationRequestsQuery(
        bool? IsSpecial,
        RequestStatus? VacationRequestStatus,
        int pageIndex = 1,
        int pageSize = 100
    ) : IRequestBase<PagingViewModel<GetAllVacationRequestsDTO>>;
    public class GetAllVacationRequestsQueryHandler : RequestHandlerBase<VacationRequest, GetAllVacationRequestsQuery, PagingViewModel<GetAllVacationRequestsDTO>>
    {
        public GetAllVacationRequestsQueryHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllVacationRequestsDTO>>> Handle(GetAllVacationRequestsQuery request,CancellationToken cancellationToken)
        {
            var roleId = _userState.RoleID;
            var userId = _userState.UserID;

            var predicate = PredicateExtensions.PredicateExtensions.Begin<VacationRequest>(true)
                .And(c => !request.VacationRequestStatus.HasValue || c.VacationRequestStatus == request.VacationRequestStatus.Value)
                .And(c => !request.IsSpecial.HasValue || c.Vacation.IsSpecial == request.IsSpecial);

            IQueryable<VacationRequest> query = _repository.Get(predicate)
                .Include(c => c.Candidate).ThenInclude(c => c.Management)
                .Include(c => c.Vacation);

            if (roleId == Role.Candidate)
            {
                query = query.Where(r => r.CandidateId == userId);
            }
            if (roleId == Role.Manager)
            {
                query = query.Where(r => r.Candidate.Management.ManagerId == userId);
            }

            var mappedQuery = await query
                .OrderByDescending(r => r.CreatedDate)
                .Map<GetAllVacationRequestsDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);


            return RequestResult<PagingViewModel<GetAllVacationRequestsDTO>>.Success(mappedQuery);
        }

    }
}
