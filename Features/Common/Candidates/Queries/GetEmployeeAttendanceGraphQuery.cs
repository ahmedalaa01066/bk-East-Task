using EasyTask.Common.Requests;
using EasyTask.Features.Common.Attendances.Queries;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Features.Common.VacationRequests.Queries;
using EasyTask.Models.Candidates;

namespace EasyTask.Features.Common.Candidates.Queries
{
    public record GetEmployeeAttendanceGraphQuery(DateOnly FromDate, DateOnly ToDate) : IRequestBase<List<EmployeeAttendanceGraphDTO>>;
    public class GetEmployeeAttendanceGraphQueryHandler : RequestHandlerBase<Candidate, GetEmployeeAttendanceGraphQuery, List<EmployeeAttendanceGraphDTO>>
    {
        public GetEmployeeAttendanceGraphQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<List<EmployeeAttendanceGraphDTO>>> Handle(GetEmployeeAttendanceGraphQuery request, CancellationToken cancellationToken)
        {
            // Get attendance data
            var attendanceResult = await _mediator.Send(new GetAttendanceGraphDataQuery(request.FromDate, request.ToDate), cancellationToken);
            var attendanceData = attendanceResult.Data ?? new();

            // Get vacation data
            var vacationResult = await _mediator.Send(new GetGraphVacationsQuery(request.FromDate, request.ToDate), cancellationToken);
            var vacationData = vacationResult.Data ?? new();

            // Merge both datasets
            var allDates = Enumerable.Range(0, request.ToDate.DayNumber - request.FromDate.DayNumber + 1)
                .Select(offset => request.FromDate.AddDays(offset));

            var result = allDates.Select(date =>
            {
                var attendance = attendanceData.FirstOrDefault(a => a.Date == date);
                var vacations = vacationData
                .Where(v => v.Date == date)
                    .Select(v => new VacationTypeCountDTO
                    {
                        VacationType = v.VacationName,
                        Count = v.NumOfCandidateTakeVacation
                    })
                    .ToList();

                return new EmployeeAttendanceGraphDTO
                {
                    Date = date,
                    AttendanceCount = attendance?.AttendanceCount ?? 0,
                    Vacations = vacations
                };
            }).ToList();

            return RequestResult<List<EmployeeAttendanceGraphDTO>>.Success(result);
        }
    }
}
