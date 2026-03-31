using EasyTask.Common.Requests;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Candidates.EditCandidateLevel.Command
{
    public record EditCandidateLevelCommand(
         string ID,
        string LevelId
    ) : IRequestBase<bool>;

    public class EditCandidateLevelCommandHandler : RequestHandlerBase<Candidate, EditCandidateLevelCommand, bool>
    {
        public EditCandidateLevelCommandHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditCandidateLevelCommand request, CancellationToken cancellationToken)
        {
            var Candidate = new Candidate
            {
                ID = request.ID,
                LevelId = request.LevelId
            };

            _repository.SaveIncluded(Candidate, nameof(Candidate.LevelId));

            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
