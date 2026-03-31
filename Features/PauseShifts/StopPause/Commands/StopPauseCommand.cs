using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.PauseShifts;

namespace EasyTask.Features.PauseShifts.StopPause.Commands
{
    public record StopPauseCommand(string ID):IRequestBase<TimeSpan>;
    public class StopPauseCommandHandler : RequestHandlerBase<PauseShift, StopPauseCommand, TimeSpan>
    {
        public StopPauseCommandHandler(RequestHandlerBaseParameters<PauseShift> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<TimeSpan>> Handle(StopPauseCommand request, CancellationToken cancellationToken)
        {
            var Pause = await _repository.GetByIDAsync(request.ID);
            if (Pause == null)
                return RequestResult<TimeSpan>.Failure(ErrorCode.NotFound);

            Pause.ToTime = DateTime.Now.TimeOfDay;

            _repository.SaveIncluded(Pause, nameof(Pause.ToTime));

            _repository.SaveChanges();
            TimeSpan TotalPauseTime = DateTime.Now.TimeOfDay - Pause.FromTime;
            return RequestResult<TimeSpan>.Success(TotalPauseTime);
        }
    }
}
