using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Attendances.Queries;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Features.Common.SpecialDays.Queries;
using EasyTask.Features.Common.VacationRequests.Queries;
using EasyTask.Helpers;
using EasyTask.Models.Attendances;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using EasyTask.Models.SpecialDays;
using EasyTask.Models.VacationRequests;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EasyTask.Features.Common.Candidates.Queries
{
    public record GetCandidatesWeeklyStatusQuery(string? SearchText,DateOnly? StartDate,DateOnly? EndDate, int PageIndex = 1, int PageSize = 10) : IRequestBase<PagingViewModel<GetCandidatesWeeklyStatusDTO>>;
    public class GetCandidatesWeeklyStatusQueryHandler : RequestHandlerBase<Candidate, GetCandidatesWeeklyStatusQuery, PagingViewModel<GetCandidatesWeeklyStatusDTO>>
    {
        public GetCandidatesWeeklyStatusQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetCandidatesWeeklyStatusDTO>>> Handle(
                GetCandidatesWeeklyStatusQuery request,
                CancellationToken cancellationToken)
            {
            var today = DateTime.Now;

            DateOnly startDate;
            DateOnly endDate;

            if (request.StartDate.HasValue && !request.EndDate.HasValue)
            {
                startDate = request.StartDate.Value;
                endDate = request.StartDate.Value;
            }
            else if (!request.StartDate.HasValue && !request.EndDate.HasValue)
            {
                int diff = (7 + (int)today.DayOfWeek - (int)DayOfWeek.Monday) % 7;
                var lastWeekStart = today.AddDays(-diff - 7);
                startDate = DateOnly.FromDateTime(lastWeekStart);
                endDate = startDate.AddDays(6);
            }
            else
            {
                startDate = request.StartDate ?? DateOnly.FromDateTime(today);
                endDate = request.EndDate ?? startDate;
            }

            var startDateTime = startDate.ToDateTime(TimeOnly.MinValue);
            var endDateTime = endDate.ToDateTime(TimeOnly.MaxValue);

            var weekDays = Enumerable.Range(0, (endDate.DayNumber - startDate.DayNumber) + 1)
                                     .Select(i => startDate.AddDays(i))
                                     .ToList();

                var specialDaysResult = await _mediator.Send(
                    new GetSpecialDaysInRangeQuery(startDate, weekDays.Last()), cancellationToken);
                var specialDays = specialDaysResult.Data ?? new List<SpecialDay>();

                var vacationRequestsResult = await _mediator.Send(
                    new GetVacationRequestsInRangeQuery(startDate, weekDays.Last()), cancellationToken);
                var vacationRequests = vacationRequestsResult.Data ?? new List<VacationRequest>();

                var attendanceResult = await _mediator.Send(
                    new GetCandidateAttendanceInRangeQuery(startDate, weekDays.Last()), cancellationToken);
                var attendances = attendanceResult.Data ?? new List<Attendance>();
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Candidate>(true);

            predicate = predicate
                .And(c => string.IsNullOrEmpty(request.SearchText) ||
                c.FirstName.Contains(request.SearchText) ||
                c.LastName.Contains(request.SearchText));

                var query = await _repository.Get(predicate)
                    .Include(c => c.Department)
                    .OrderBy(c => c.FirstName).Map<GetCandidatesWeeklyStatusDTO>().ToPagesAsync(request.PageIndex, request.PageSize);


            foreach (var candidate in query.Items)
            {
                var weeklyStatuses = new List<WeeklyStatusEntryDTO>(); 

                foreach (var day in weekDays)
                {
                    DayStatus? status = null;

                    if (day.DayOfWeek == DayOfWeek.Friday || day.DayOfWeek == DayOfWeek.Saturday)
                    {
                        status = DayStatus.Weekend;
                    }
                    else if (specialDays.Any(sd =>
                                (sd.IsOneDay && sd.FromDate == day) ||
                                (!sd.IsOneDay && sd.FromDate <= day && sd.ToDate >= day)))
                    {
                        status = DayStatus.SpecialDay;
                    }
                    else
                    {
                        var vacation = vacationRequests.FirstOrDefault(vr =>
                            vr.CandidateId == candidate.CandidateId &&
                            vr.FromDate <= day && vr.ToDate >= day);

                        if (vacation != null)
                        {
                            if (vacation.Vacation?.IsSpecial == true)
                                status = DayStatus.WFH;
                            else if (vacation.Vacation?.Name == "Annual")
                                status = DayStatus.Annual;
                            else
                                status = DayStatus.Absent;
                        }
                        else
                        {
                            var attendance = attendances.FirstOrDefault(a =>
                                a.CandidateId == candidate.CandidateId &&
                                a.PlannedStartDate.Date == day.ToDateTime(TimeOnly.MinValue).Date);

                            if (attendance != null)
                                status = DayStatus.Office;
                        }
                    }

                    status ??= DayStatus.Absent;

                    weeklyStatuses.Add(new WeeklyStatusEntryDTO
                    {
                        DayName = day.DayOfWeek.ToString(),
                        Date = day,
                        Status = status.Value
                    });
                }
                candidate.WeeklyStatuses = weeklyStatuses;
            }


            return RequestResult< PagingViewModel < GetCandidatesWeeklyStatusDTO >>.Success(query);
            }
        }
    }

