using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Attendances;

namespace EasyTask.Features.Attendances.EditAttendancePause.Command
{
    public record EditAttendancePauseCommand(string ID, TimeSpan? TotalPauseDuration) : IRequestBase<bool>;
    public class EditAttendancePauseCommandHandler : RequestHandlerBase<Attendance, EditAttendancePauseCommand, bool>
    {
        public EditAttendancePauseCommandHandler(RequestHandlerBaseParameters<Attendance> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditAttendancePauseCommand request, CancellationToken cancellationToken)
        {

            var attendance = await _repository.GetByIDAsync(request.ID);
            if (attendance == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            if (attendance.TotalPauseDuration == null)
                attendance.TotalPauseDuration = request.TotalPauseDuration;
            else
                attendance.TotalPauseDuration += request.TotalPauseDuration;

            _repository.SaveIncluded(attendance, nameof(attendance.TotalPauseDuration));

            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
