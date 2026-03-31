using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Attendances.Queries;
using EasyTask.Features.Common.PermissionLogs.Queries;
using EasyTask.Features.Common.PermissionRequests.Queries;
using EasyTask.Features.Common.PlannedShifts.Queries;
using EasyTask.Features.PermissionLogs.CreateFullPermissionLogs.Commands;
using EasyTask.Features.PermissionLogs.EndPermissionlogs.Commands;
using EasyTask.Models.Attendances;

namespace EasyTask.Features.Attendances.StartAttendance.Commands
{
    public record StartAttendanceCommand(string CandidateId) : IRequestBase<string>;
    public class StartAttendanceCommandHandler : RequestHandlerBase<Attendance, StartAttendanceCommand, string>
    {
        public StartAttendanceCommandHandler(RequestHandlerBaseParameters<Attendance> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(StartAttendanceCommand request, CancellationToken cancellationToken)
        {
            var Data = await _mediator.Send(new GetPlannedAttendanceDataByCandidateIdQery(request.CandidateId));
            if (!Data.IsSuccess)
                return RequestResult<string>.Failure(Data.ErrorCode);
            var now = DateTime.Now;

            var allowedStartTime = Data.Data.PlannedStartDate - Data.Data.MarginBefore;
            var allowedStartTimeAfter = Data.Data.PlannedStartDate + Data.Data.MarginAfter;
            if (now < allowedStartTime)
            {
                return RequestResult<string>.Failure(ErrorCode.WaitForShiftTime);
            }

            if (DateTime.Now > allowedStartTimeAfter)
            {
                var check = await _mediator.Send(new CheckSecondPermissionForCandidateQuery(request.CandidateId));
                if (check.Data)
                {

                    var permissionId = await _mediator.Send(new GerPermissionLogsIDQuery(request.CandidateId));
                    if (permissionId.Data != null)
                    {
                        await _mediator.Send(new EndPermissionlogsCommand(permissionId.Data));
                        var attendanceId = await _mediator.Send(new GetAttendanceIdByDateAndCandidateIdQuery(request.CandidateId));
                        if (!attendanceId.IsSuccess)
                            return RequestResult<string>.Failure(attendanceId.ErrorCode);
                        return RequestResult<string>.Success(attendanceId.Data);
                    }
                    else
                    {
                        await _mediator.Send(new CreateFullPermissionLogsCommand(request.CandidateId, Data.Data.PlannedStartDate));
                    }
                }
                else
                    return RequestResult<string>.Failure(ErrorCode.Late);

            }
            Attendance attendance = new Attendance
            {
                CandidateId = request.CandidateId,
                ShiftId = Data.Data.ShiftId,
                PlannedStartDate = Data.Data.PlannedStartDate,
                PlannedEndDate = Data.Data.PlannedEndDate,
                ActualStartDate = DateTime.Now,
                AttendanceActivation = Data.Data.AttendanceActivation,
            };
            _repository.Add(attendance);
            _repository.SaveChanges();
            return RequestResult<string>.Success(attendance.ID);
        }
    }
}
