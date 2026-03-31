using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Shifts;

namespace EasyTask.Features.Shifts.EditShift.Commands
{
    public record EditShiftCommand(
        string ID,
        string Name,
        TimeSpan FromTime,
        TimeSpan ToTime,
        bool PauseOption,
        TimeSpan? MaxPauseDuration,
        TimeSpan? MarginBefore,
        TimeSpan? MarginAfter
    ) : IRequestBase<bool>;
    public class EditShiftCommandHandler : RequestHandlerBase<Shift, EditShiftCommand, bool>
    {
        public EditShiftCommandHandler(RequestHandlerBaseParameters<Shift> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditShiftCommand request, CancellationToken cancellationToken)
        {
            var shift = await _repository.GetByIDAsync(request.ID);
            if (shift == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            shift.Name = request.Name;
            shift.FromTime = request.FromTime;
            shift.ToTime = request.ToTime;
            shift.PauseOption = request.PauseOption;
            shift.MaxPauseDuration = request.MaxPauseDuration;
            shift.MarginBefore = request.MarginBefore;
            shift.MarginAfter = request.MarginAfter;
            _repository.SaveIncluded(shift, nameof(shift.Name), nameof(shift.FromTime), nameof(shift.ToTime),
                nameof(shift.PauseOption), nameof(shift.MaxPauseDuration), nameof(shift.MarginBefore),
                nameof(shift.MarginAfter));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
