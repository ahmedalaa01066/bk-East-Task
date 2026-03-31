using EasyTask.Common.Requests;
using EasyTask.Features.Common.VacationRequests.DTOs;
using EasyTask.Models.Enums;
using EasyTask.Models.VacationRequests;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.VacationRequests.Queries
{
    public record GetGraphVacationsQuery(DateOnly FromDate, DateOnly ToDate) :IRequestBase<List<GetGraphVacationsDTO>>;
    public class GetGraphVacationsQueryHandler : RequestHandlerBase<VacationRequest, GetGraphVacationsQuery, List<GetGraphVacationsDTO>>
    {
        public GetGraphVacationsQueryHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<GetGraphVacationsDTO>>> Handle(GetGraphVacationsQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.Get()
                .Include(v => v.Vacation)
                .Where(v => 
                v.VacationRequestStatus == RequestStatus.SecondApproval &&
                v.FromDate >= request.FromDate &&
                v.FromDate <= request.ToDate)
                .GroupBy(v => new { v.FromDate, v.Vacation.Name })
                .Select(g => new GetGraphVacationsDTO
                {
                    Date = g.Key.FromDate,
                    VacationName = g.Key.Name,
                    NumOfCandidateTakeVacation = g.Count()
                })
                .ToListAsync(cancellationToken);

            return RequestResult<List<GetGraphVacationsDTO>>.Success(data);
        }
    }
}
