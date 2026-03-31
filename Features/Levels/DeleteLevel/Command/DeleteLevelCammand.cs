using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Levels;

namespace EasyTask.Features.Levels.DeleteLevel.Command;

public record DeleteLevelCammand(string ID) : IRequestBase<bool>;

public class DeleteLevelCammandHandler : RequestHandlerBase<Level, DeleteLevelCammand, bool>
{
    public DeleteLevelCammandHandler(RequestHandlerBaseParameters<Level> parameters) : base(parameters) { }

    public async override Task<RequestResult<bool>> Handle(DeleteLevelCammand request, CancellationToken cancellationToken)
    {
        var check = await _repository.AnyAsync(b => b.ID == request.ID);
        if (!check)
            return RequestResult<bool>.Failure(ErrorCode.NotFound);
     
        _repository.Delete(request.ID);
        _repository.SaveChanges();
        return await Task.FromResult(RequestResult<bool>.Success(true));
    }
}
