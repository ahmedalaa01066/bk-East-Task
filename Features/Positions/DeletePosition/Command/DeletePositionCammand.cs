using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Positions;

namespace EasyTask.Features.Positions.DeletePosition.Command;

public record DeletePositionCammand(string ID) : IRequestBase<bool>;

public class DeletePositionCammandHandler : RequestHandlerBase<Position, DeletePositionCammand, bool>
{
    public DeletePositionCammandHandler(RequestHandlerBaseParameters<Position> parameters) : base(parameters) { }

    public async override Task<RequestResult<bool>> Handle(DeletePositionCammand request, CancellationToken cancellationToken)
    {
        var check = await _repository.AnyAsync(b => b.ID == request.ID);
        if (!check)
            return RequestResult<bool>.Failure(ErrorCode.NotFound);
     
        _repository.Delete(request.ID);
        _repository.SaveChanges();
        return await Task.FromResult(RequestResult<bool>.Success(true));
    }
}
