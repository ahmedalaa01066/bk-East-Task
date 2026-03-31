using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.PermissionRequests.Queries;
using EasyTask.Features.PermissionLogs.CreatePermissionLogs.Commands;
using EasyTask.Models.Attendances;

namespace EasyTask.Features.Attendances.EndAttendance.Commands
{
    public record EndAttendanceCommand(string ID) : IRequestBase<bool>;
    public class EndAttendanceCommandHandler : RequestHandlerBase<Attendance, EndAttendanceCommand, bool>
    {
        public EndAttendanceCommandHandler(RequestHandlerBaseParameters<Attendance> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EndAttendanceCommand request, CancellationToken cancellationToken)
        {
            var Data = _repository.GetByID(request.ID);
            if (Data.PlannedEndDate > DateTime.Now)
            {
                var check = await _mediator.Send(new CheckSecondPermissionForCandidateForLeaveQuery(Data.CandidateId));
                if (check.Data)
                {
                    _mediator.Send(new CreatePermissionLogsCommand(Data.CandidateId));
                    return RequestResult<bool>.Success(true);
                }
                else
                {
                    return RequestResult<bool>.Failure(ErrorCode.NotHavePermission);
                }

            }
            var Attendance = new Attendance
            {
                ID = request.ID,
                ActualEndDate = DateTime.Now
            };

            _repository.SaveIncluded(Attendance, nameof(Attendance.ActualEndDate));

            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
