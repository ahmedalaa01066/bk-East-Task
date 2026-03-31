using EasyTask.Common.Requests;
using EasyTask.Models.Positions;

namespace EasyTask.Features.Positions.CreatePosition.Commands
{
    public record CreatePositionCommand(string Name):IRequestBase<bool>;
    public class CreatePositionCommandHandler : RequestHandlerBase<Position, CreatePositionCommand, bool>
    {
        public CreatePositionCommandHandler(RequestHandlerBaseParameters<Position> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            Position position = new Position { Name = request.Name };
            _repository.Add(position);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
