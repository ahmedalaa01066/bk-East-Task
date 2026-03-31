using EasyTask.Common.Requests;
using EasyTask.Models.Attendances;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Attendances.Queries
{
    public record GetCandidateAttendanceInRangeQuery(DateOnly StartDate, DateOnly EndDate)
        : IRequestBase<List<Attendance>>;

    public class GetCandidateAttendanceInRangeQueryHandler
        : RequestHandlerBase<Attendance, GetCandidateAttendanceInRangeQuery, List<Attendance>>
    {
        public GetCandidateAttendanceInRangeQueryHandler(RequestHandlerBaseParameters<Attendance> requestParameters)
            : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<Attendance>>> Handle(
            GetCandidateAttendanceInRangeQuery request,
            CancellationToken cancellationToken)
        {
            var startDateTime = request.StartDate.ToDateTime(TimeOnly.MinValue);
            var endDateTime = request.EndDate.ToDateTime(TimeOnly.MaxValue);

            var result = await _repository
                .Get(a => a.PlannedStartDate >= startDateTime && a.PlannedStartDate <= endDateTime)
                .ToListAsync(cancellationToken);

            return RequestResult<List<Attendance>>.Success(result);
        }
    }
}
