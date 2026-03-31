using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Shifts;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Shifts.Queries
{
    public record CheckShiftPauseOptionQuery(string ID) : IRequestBase<TimeSpan>;

    public class CheckShiftPauseOptionQueryHandler
        : RequestHandlerBase<Shift, CheckShiftPauseOptionQuery, TimeSpan>
    {
        public CheckShiftPauseOptionQueryHandler(RequestHandlerBaseParameters<Shift> requestParameters)
            : base(requestParameters)
        {
        }

        public async override Task<RequestResult<TimeSpan>> Handle(CheckShiftPauseOptionQuery request, CancellationToken cancellationToken)
        {
            var shift = await _repository
                .Get(s => s.ID == request.ID)
                .FirstOrDefaultAsync(cancellationToken);

            if (shift == null)
                return RequestResult<TimeSpan>.Failure(ErrorCode.ShiftNotFound);

            if (shift.PauseOption && shift.MaxPauseDuration.HasValue)
            {
                var formatted = shift.MaxPauseDuration.Value;
                return RequestResult<TimeSpan>.Success(formatted);
            }

            return RequestResult<TimeSpan>.Failure(ErrorCode.NoPauseOptionForShift);
        }
    }
}
