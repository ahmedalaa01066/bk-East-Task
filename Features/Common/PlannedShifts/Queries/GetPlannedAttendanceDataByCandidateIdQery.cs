using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.PlannedShifts.DTOs;
using EasyTask.Models.PlannedShifts;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.PlannedShifts.Queries
{
    public record GetPlannedAttendanceDataByCandidateIdQery(string CandidateId) : IRequestBase<GetPlannedAttendanceDataByCandidateIdDTO>;
    public class GetPlannedAttendanceDataByCandidateIdQeryHandler : RequestHandlerBase<PlannedShift, GetPlannedAttendanceDataByCandidateIdQery, GetPlannedAttendanceDataByCandidateIdDTO>
    {
        public GetPlannedAttendanceDataByCandidateIdQeryHandler(RequestHandlerBaseParameters<PlannedShift> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<GetPlannedAttendanceDataByCandidateIdDTO>> Handle(GetPlannedAttendanceDataByCandidateIdQery request, CancellationToken cancellationToken)
        {
            var Data = await _repository.Get(ps => ps.CandidateId == request.CandidateId &&
            ps.StartDate <= DateTime.Now
            && ps.EndDate >= DateTime.Now)
                .Include(ps => ps.Shift)
                .Include(ps => ps.Candidate)
                .FirstOrDefaultAsync();
            if (Data == null)
                return RequestResult<GetPlannedAttendanceDataByCandidateIdDTO>.Failure(ErrorCode.NotHaveShift);
            var result = new GetPlannedAttendanceDataByCandidateIdDTO
            {
                ShiftId = Data.ShiftId,
                PlannedStartDate = DateTime.Now.Date + Data.Shift.FromTime,
                PlannedEndDate = (Data.Shift.ToTime > Data.Shift.FromTime)
                ? DateTime.Now.Date + Data.Shift.ToTime
                : DateTime.Now.Date.AddDays(1) + Data.Shift.ToTime,
                AttendanceActivation = Data.Candidate.AttendanceActivation,
                MarginAfter = Data.Shift.MarginAfter,
                MarginBefore = Data.Shift.MarginBefore,
            };
            return RequestResult<GetPlannedAttendanceDataByCandidateIdDTO>.Success(result);
        }
    }
}
