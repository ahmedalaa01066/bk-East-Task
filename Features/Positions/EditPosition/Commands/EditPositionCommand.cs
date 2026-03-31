using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Positions;

namespace EasyTask.Features.Positions.EditPositions.Commands
{
    public record EditPositionCommand(string ID,string Name):IRequestBase<bool>;
    public class EditPositionsCommandHandler : RequestHandlerBase<Position, EditPositionCommand, bool>
    {
        public EditPositionsCommandHandler(RequestHandlerBaseParameters<Position> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditPositionCommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            Position Position = new Position { ID = request.ID };
            Position.Name = request.Name;
            _repository.SaveIncluded(Position, nameof(Position.Name));
            _repository.SaveChanges();
            var result = RequestResult<bool>.Success(true);
            return await Task.FromResult(result);
        }
    }
}
