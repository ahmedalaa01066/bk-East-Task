using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.PlannedShifts.EditPlannedShift.Command;
using EasyTask.Models.PlannedShifts;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.PlannedShifts.AssignCandidateToShift.Orchestartor
{
    public record AssignCandidateToShiftOrchestartor(
    DateTime StartDate,
    DateTime EndDate,
    List<string> CandidateIds,
    string ShiftId
) : IRequestBase<bool>;

    public class AssignCandidateToShiftOrchestartorHandler: RequestHandlerBase<PlannedShift, AssignCandidateToShiftOrchestartor, bool>
    {
        public AssignCandidateToShiftOrchestartorHandler(RequestHandlerBaseParameters<PlannedShift> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(AssignCandidateToShiftOrchestartor request,CancellationToken cancellationToken)
        {
            foreach (var candidateId in request.CandidateIds)
            {
                var existingShifts = await _repository.Get()
                    .Where(x => x.CandidateId == candidateId &&
                    x.StartDate <= request.EndDate &&
                    x.EndDate >= request.StartDate)
                    .ToListAsync();

                var groupedByDay = existingShifts
                    .GroupBy(x => x.StartDate.Date)
                    .ToDictionary(g => g.Key, g => g.Count());

                for (var date = request.StartDate.Date; date <= request.EndDate.Date; date = date.AddDays(1))
                {
                    groupedByDay.TryGetValue(date, out var existingCount);
                    if (existingCount >= 2)
                    {
                        return RequestResult<bool>.Failure(ErrorCode.ShiftTimeOutOfRange,
                            $"Candidate {candidateId} already has 2 shifts on {date:yyyy-MM-dd}.");
                    }
                }

                foreach (var s in existingShifts)
                {
                    if (ShiftsOverlap(s.StartDate, s.EndDate, request.StartDate, request.EndDate))
                    {
                        return RequestResult<bool>.Failure(ErrorCode.ShiftTimeOutOfRange,
                            $"Candidate {candidateId} has overlapping shift ({s.StartDate:yyyy-MM-dd HH:mm} - {s.EndDate:yyyy-MM-dd HH:mm}).");
                    }
                }
                var newShift = new PlannedShift
                {
                    CandidateId = candidateId,
                    ShiftId = request.ShiftId,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate
                };

                _repository.Add(newShift);

            }

             _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }

        //private static bool ShiftsOverlap(DateTime aStart, DateTime aEnd, DateTime bStart, DateTime bEnd)
        //{
        //    return aStart < bEnd && bStart < aEnd;
        //}

        private static bool ShiftsOverlap(DateTime aStart, DateTime aEnd, DateTime bStart, DateTime bEnd)
        {
            // Normalize shifts that cross midnight
            if (aEnd <= aStart) aEnd = aEnd.AddDays(1);
            if (bEnd <= bStart) bEnd = bEnd.AddDays(1);

            return aStart < bEnd && bStart < aEnd;
        }
    }

}

