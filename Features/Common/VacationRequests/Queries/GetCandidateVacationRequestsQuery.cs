using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.VacationRequests.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.VacationRequests;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.VacationRequests.Queries
{
    public record GetCandidateVacationRequestsQuery(
        int pageIndex = 1,
        int pageSize = 100
    ) : IRequestBase<PagingViewModel<GetCandidateVacationRequestsDTO>>;
    public class GetCandidateVacationRequestsQueryHandler : RequestHandlerBase<VacationRequest, GetCandidateVacationRequestsQuery, PagingViewModel<GetCandidateVacationRequestsDTO>>
    {
        public GetCandidateVacationRequestsQueryHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetCandidateVacationRequestsDTO>>> Handle(GetCandidateVacationRequestsQuery request,CancellationToken cancellationToken)
        {
            var query = await _repository
                .Get(r => r.CandidateId == _userState.UserID)
                .Include(c=>c.Vacation)
                .Map<GetCandidateVacationRequestsDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetCandidateVacationRequestsDTO>>.Success(query);
        }

    }
}
