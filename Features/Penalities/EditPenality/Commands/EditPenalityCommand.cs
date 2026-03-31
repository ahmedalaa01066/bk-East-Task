using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Penalities;

namespace EasyTask.Features.Penalities.EditPenality.Commands
{
    public record EditPenalityCommand(string ID, string Description) : IRequestBase<bool>;
    public class EditPenalityCommandHandler : RequestHandlerBase<Penality, EditPenalityCommand, bool>
    {
        public EditPenalityCommandHandler(RequestHandlerBaseParameters<Penality> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditPenalityCommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            Penality penality = new Penality { ID = request.ID };
            penality.Description = request.Description;
            _repository.SaveIncluded(penality, nameof(penality.Description));
            _repository.SaveChanges();
            var result = RequestResult<bool>.Success(true);
            return await Task.FromResult(result);
        }
    }
}
