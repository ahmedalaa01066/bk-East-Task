using EasyTask.Common.Requests;
using EasyTask.Models.Shifts;

namespace EasyTask.Features.Shifts.CreateShift.Commands
{
    public record CreateShiftCommand(string Name, TimeSpan FromTime, TimeSpan ToTime,
        bool PauseOption, TimeSpan? MaxPauseDuration, TimeSpan? MarginBefore, TimeSpan? MarginAfter) : IRequestBase<bool>;
    public class CreateShiftCommandHandler : RequestHandlerBase<Shift, CreateShiftCommand, bool>
    {
        public CreateShiftCommandHandler(RequestHandlerBaseParameters<Shift> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateShiftCommand request, CancellationToken cancellationToken)
        {
            Shift shift = new Shift
            {
                Name = request.Name,
                FromTime = request.FromTime,
                ToTime = request.ToTime,
                PauseOption = request.PauseOption,
                MaxPauseDuration = request.MaxPauseDuration,
                MarginBefore = request.MarginBefore,
                MarginAfter = request.MarginAfter
            };
            _repository.Add(shift);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
