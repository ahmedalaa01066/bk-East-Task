using EasyTask.Common.Requests;
using EasyTask.Features.Common.Attendances.DTOs;
using EasyTask.Models.Attendances;
using EasyTask.Models.Candidates;
using Microsoft.EntityFrameworkCore;
namespace EasyTask.Features.Common.Attendances.Queries
{
    public record GetAttendanceGraphDataQuery(DateOnly FromDate, DateOnly ToDate) : IRequestBase<List<AttendanceDailyCountDTO>>;
    public class GetAttendanceGraphDataQueryHandler : RequestHandlerBase<Attendance, GetAttendanceGraphDataQuery, List<AttendanceDailyCountDTO>>
    {
        public GetAttendanceGraphDataQueryHandler(RequestHandlerBaseParameters<Attendance> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<AttendanceDailyCountDTO>>> Handle(GetAttendanceGraphDataQuery request, CancellationToken cancellationToken)
        {
            var fromDate = request.FromDate.ToDateTime(TimeOnly.MinValue);
            var toDate = request.ToDate.ToDateTime(TimeOnly.MaxValue);

            var predicate = PredicateExtensions.PredicateExtensions.Begin<Candidate>(true);

            predicate = predicate;

            var data = await _repository.Get()
                .Where(a => a.ActualStartDate >= fromDate && a.ActualStartDate <= toDate)
                .GroupBy(a => a.ActualStartDate.Date)
                .Select(g => new AttendanceDailyCountDTO
                {
                    Date = DateOnly.FromDateTime(g.Key),
                    AttendanceCount = g.Count()
                })
                .ToListAsync(cancellationToken);

            return RequestResult<List<AttendanceDailyCountDTO>>.Success(data);
        }
    }
}
