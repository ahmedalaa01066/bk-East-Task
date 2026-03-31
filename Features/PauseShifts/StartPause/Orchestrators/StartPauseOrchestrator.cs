using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Attendances.Queries;
using EasyTask.Features.Common.Shifts.Queries;
using EasyTask.Features.PauseShifts.StartPause.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Attendances;
using EasyTask.Models.PauseShifts;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.PauseShifts.StartPause.Orchestrators
{
    public record StartPauseOrchestrator(string AttendanceId) : IRequestBase<string>;
    public class StartPauseOrchestratorHandler : RequestHandlerBase<PauseShift, StartPauseOrchestrator, string>
    {
        public StartPauseOrchestratorHandler(RequestHandlerBaseParameters<PauseShift> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(StartPauseOrchestrator request, CancellationToken cancellationToken)
        {

            var attendance = await _mediator.Send(new GetShiftAndPauseDurationByIDQuery(request.AttendanceId));
            if (!attendance.IsSuccess) {
                return RequestResult<string>.Failure(attendance.ErrorCode);
            }
            var PauseTime = await _mediator.Send(new CheckShiftPauseOptionQuery(attendance.Data.ShiftId));
            if (!PauseTime.IsSuccess)
            {
                return RequestResult<string>.Failure(PauseTime.ErrorCode);
            }
            var maxAllowedPause = PauseTime.Data; 

            var usedPause = attendance.Data.TotalPauseDuration ?? TimeSpan.Zero;

            if (usedPause >= maxAllowedPause)
                return RequestResult<string>.Failure(ErrorCode.PauseTimeEnded);

            var AddPause = await _mediator.Send(request.MapOne<StartPauseCommand>());
            if (!AddPause.IsSuccess)
            {
                return RequestResult<string>.Failure(AddPause.ErrorCode);
            }
            return RequestResult<string>.Success(AddPause.Data);
        }
    }
}
