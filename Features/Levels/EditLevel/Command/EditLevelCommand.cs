using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Data;
using EasyTask.Models.Levels;

namespace EasyTask.Features.Levels.EditLevel.Commands
{
    public record EditLevelCommand(string Id, string Name, int Sequence) : IRequestBase<bool>;

    public class EditLevelCommandHandler : RequestHandlerBase<Level, EditLevelCommand, bool>
    {
        public EditLevelCommandHandler(RequestHandlerBaseParameters<Level> requestParameters)
            : base(requestParameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(EditLevelCommand request, CancellationToken cancellationToken)
        {
            var Level = await _repository.GetByIDAsync(request.Id);
            if (Level==null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            Level.Name = request.Name;
            Level.Sequence = request.Sequence;  
            _repository.SaveIncluded(Level, nameof(Level.Name), nameof(Level.Sequence));

            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
