using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Candidates;

namespace EasyTask.Features.Candidates.DeleteCandidate.Commands
{
    public record DeleteCandidateCommand(string ID):IRequestBase<bool>;
    public class DeleteCandidateCommandHandler : RequestHandlerBase<Candidate, DeleteCandidateCommand, bool>
    {
        public DeleteCandidateCommandHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
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
