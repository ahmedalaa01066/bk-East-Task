using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Attendances.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Attendances;
using Microsoft.EntityFrameworkCore;
using PredicateExtensions.Core;

namespace EasyTask.Features.Common.Attendances.Queries
{
    public record GetAllShiftsDetailsForCandidateQuery(
        string CandidateId,
        DateOnly? From,
        DateOnly? TO,
        int pageIndex = 1,
        int pageSize = 100
    ) : IRequestBase<PagingViewModel<GetAllShiftsDetailsForCandidateDTO>>;
    public class GetAllShiftsDetailsForCandidateQueryHandler : RequestHandlerBase<Attendance, GetAllShiftsDetailsForCandidateQuery, PagingViewModel<GetAllShiftsDetailsForCandidateDTO>>
    {
        public GetAllShiftsDetailsForCandidateQueryHandler(RequestHandlerBaseParameters<Attendance> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllShiftsDetailsForCandidateDTO>>> Handle(GetAllShiftsDetailsForCandidateQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Attendance>(true);

            predicate = predicate
                .And(c => string.IsNullOrEmpty(request.CandidateId) || c.CandidateId == request.CandidateId)
                .And(t => !request.From.HasValue || DateOnly.FromDateTime(t.ActualStartDate) >= request.From.Value)
                .And(t => !request.TO.HasValue || (t.ActualEndDate.HasValue &&
                        DateOnly.FromDateTime(t.ActualEndDate.Value) <= request.TO.Value));

            var model = await _repository
                .Get(predicate)
                .Include(a => a.PauseShifts)
                .OrderByDescending(a => a.ActualStartDate)
                .ToPagesAsync(request.pageIndex, request.pageSize);
            // Transform into logs
            var logs = new List<GetAllShiftsDetailsForCandidateDTO>();

            foreach (var att in model.Items)
            {
                // Start shift
                logs.Add(new GetAllShiftsDetailsForCandidateDTO
                {
                    Log = $"Start shift at {att.ActualStartDate:hh:mm tt}",
                    Time = att.ActualStartDate.TimeOfDay,
                    Date = att.ActualStartDate.Date
                });

                // Pauses
                foreach (var pause in att.PauseShifts.OrderBy(p => p.FromTime))
                {
                    var pauseStart = att.ActualStartDate.Date + pause.FromTime;
                    if (pause.ToTime.HasValue)
                    {
                        var pauseEnd = att.ActualStartDate.Date + pause.ToTime.Value;
                        if (pauseEnd < pauseStart)
                            pauseEnd = pauseEnd.AddDays(1);
                        logs.Add(new GetAllShiftsDetailsForCandidateDTO
                        {
                            Log = $"Pause from {pauseStart:hh:mm tt} to {pauseEnd:hh:mm tt}",
                            Time = pause.FromTime,
                            Date = att.ActualStartDate.Date
                        });
                    }
                    else
                    {
                        logs.Add(new GetAllShiftsDetailsForCandidateDTO
                        {
                            Log = $"Pause started at {pauseStart:hh:mm tt}",
                            Time = pause.FromTime,
                            Date = att.ActualStartDate.Date
                        });
                    }
                }

                // End shift
                if (att.ActualEndDate.HasValue)
                {
                    var endDt = att.ActualEndDate.Value;
                    logs.Add(new GetAllShiftsDetailsForCandidateDTO
                    {
                        Log = $"End shift at {endDt:hh:mm tt}",
                        Time = att.ActualEndDate.Value.TimeOfDay,
                        Date = att.ActualEndDate.Value.Date
                    });
                }
            }

            // Apply paging again if needed
            var pagedLogs = new PagingViewModel<GetAllShiftsDetailsForCandidateDTO>
            {
                Items = logs.Skip((request.pageIndex - 1) * request.pageSize).Take(request.pageSize),
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Records = logs.Count,
                Pages = (int)Math.Ceiling((double)logs.Count / request.pageSize)
            };

            return RequestResult<PagingViewModel<GetAllShiftsDetailsForCandidateDTO>>.Success(pagedLogs);
        }
    }
}
