using EasyTask.Common.Requests;
using EasyTask.Features.Common.CandidateVacations.DTOs;
using EasyTask.Features.Common.Vacations.Queries;
using EasyTask.Models.CandidateVacations;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.CandidateVacations.Queries
{
    public record GetCandidateVacationRemainingDaysQuery(string? CandidateId):IRequestBase<GetCandidateVacationRemainingDaysDTO>;
    public class GetCandidateVacationRemainingDaysQueryHandler : RequestHandlerBase<CandidateVacation, GetCandidateVacationRemainingDaysQuery, GetCandidateVacationRemainingDaysDTO>
    {
        public GetCandidateVacationRemainingDaysQueryHandler(RequestHandlerBaseParameters<CandidateVacation> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetCandidateVacationRemainingDaysDTO>> Handle(GetCandidateVacationRemainingDaysQuery request, CancellationToken cancellationToken)
        {
            var yearStart = new DateTime(DateTime.Now.Year, 1, 1);
            var yearEnd = new DateTime(DateTime.Now.Year, 12, 31);

            var maxVacation = await _mediator.Send(new GetMaxVacationDaysQuery());
            var maxDays = maxVacation.Data; 

            var usedDays = await _repository.Get().Include(v=>v.Vacation)
                .Where(cv => cv.CandidateId == (request.CandidateId ?? _userState.UserID))
                .SumAsync(cv =>cv.Vacation.MaxRequestNum - cv.Counter );  

            var remainingDays = maxDays - usedDays;

            var result = new GetCandidateVacationRemainingDaysDTO(
                maxDays,
                remainingDays
            );

            return RequestResult<GetCandidateVacationRemainingDaysDTO>.Success(result);

        }
    }
}
