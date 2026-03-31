using EasyTask.Common.Requests;
using EasyTask.Features.Attendances.EditAttendancePause.Command;
using EasyTask.Features.PauseShifts.StopPause.Commands;
using EasyTask.Helpers;
using EasyTask.Models.PauseShifts;

namespace EasyTask.Features.PauseShifts.StopPause.Orchestrators
{
    public record StopPauseOrchestrator(string ID) : IRequestBase<bool>;
    public class StopPauseOrchestratorHandler : RequestHandlerBase<PauseShift, StopPauseOrchestrator, bool>
    {
        public StopPauseOrchestratorHandler(RequestHandlerBaseParameters<PauseShift> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(StopPauseOrchestrator request, CancellationToken cancellationToken)
        {
            var TotalPauseTime = await _mediator.Send(request.MapOne<StopPauseCommand>());
            if (!TotalPauseTime.IsSuccess)
            {
                return RequestResult<bool>.Failure(TotalPauseTime.ErrorCode);
            }
            var attendanceId = _repository.Get(p => p.ID == request.ID).FirstOrDefault()!.AttendanceId;
            var editAttendancePause = await _mediator.Send(new EditAttendancePauseCommand(attendanceId, TotalPauseTime.Data));
            if (!editAttendancePause.IsSuccess)
            {
                return RequestResult<bool>.Failure(editAttendancePause.ErrorCode);
            }
            return RequestResult<bool>.Success(true);
        }
    }
}
