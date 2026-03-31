using EasyTask.Common.Requests;
using EasyTask.Models.PauseShifts;

namespace EasyTask.Features.PauseShifts.StartPause.Commands
{
    public record StartPauseCommand(string AttendanceId):IRequestBase<string>;
    public class StartPauseCommandHandler : RequestHandlerBase<PauseShift, StartPauseCommand, string>
    {
        public StartPauseCommandHandler(RequestHandlerBaseParameters<PauseShift> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(StartPauseCommand request, CancellationToken cancellationToken)
        {
            var Pause = new PauseShift
            {
                AttendanceId = request.AttendanceId,
                FromTime = DateTime.Now.TimeOfDay 
            };

            await _repository.AddAsync(Pause);
             _repository.SaveChanges();

            return RequestResult<string>.Success(Pause.ID);

        }
    }
}
