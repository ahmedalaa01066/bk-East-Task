using EasyTask.Common.Requests;
using EasyTask.Features.Common.Attendances.Queries;
using EasyTask.Features.Common.PlannedShifts.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.PlannedShifts;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.PlannedShifts.Queries
{
    public record GetAllPlannedShiftsByCandidateIdQuery(string CandidateId) :IRequestBase<List<GetAllPlannedShiftsByCandidateIdDTO>>;
    public class GetAllPlannedShiftsByCandidateIdQueryHandler : RequestHandlerBase<PlannedShift, GetAllPlannedShiftsByCandidateIdQuery, List<GetAllPlannedShiftsByCandidateIdDTO>>
{
        public GetAllPlannedShiftsByCandidateIdQueryHandler(RequestHandlerBaseParameters<PlannedShift> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<List<GetAllPlannedShiftsByCandidateIdDTO>>> Handle(GetAllPlannedShiftsByCandidateIdQuery request, CancellationToken cancellationToken)
        {
            List<PlannedShift> entity = await _repository
                .Get(ps => ps.CandidateId == request.CandidateId &&
                        (DateTime.Now.Date >= ps.StartDate || DateTime.Now.Date <= ps.EndDate))
                .Include(ps => ps.Shift)
                .ToListAsync();
            List<GetAllPlannedShiftsByCandidateIdDTO> dto = entity.MapList<GetAllPlannedShiftsByCandidateIdDTO>().ToList();
            foreach (var item in dto)
            {
                var attendanceId = await _mediator.Send(new GetTodayCandidateAttendance(request.CandidateId,item.ShiftId));
                item.AttendanceId = attendanceId.Data;
            }
            return RequestResult<List<GetAllPlannedShiftsByCandidateIdDTO>>.Success(dto);
        }
    }
}
