using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Penalities;

namespace EasyTask.Features.Penalities.DeletePenality.Commands
{
    public record DeletePenalityCommand(string ID):IRequestBase<bool>;
    public class DeletePenalityCommandHandler : RequestHandlerBase<Penality, DeletePenalityCommand, bool>
    {
        public DeletePenalityCommandHandler(RequestHandlerBaseParameters<Penality> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeletePenalityCommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            _repository.Delete(request.ID);
            _repository.SaveChanges();
            return await Task.FromResult(RequestResult<bool>.Success(true));
        }
    }
}
