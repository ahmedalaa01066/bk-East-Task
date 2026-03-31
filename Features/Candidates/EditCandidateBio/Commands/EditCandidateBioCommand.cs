using EasyTask.Common.Requests;
using EasyTask.Models.Candidates;

namespace EasyTask.Features.Candidates.EditCandidateBio.Commands
{
    public record EditCandidateBioCommand(string ID, string Bio):IRequestBase<bool>;
    public class EditCandidateBioCommandHandler : RequestHandlerBase<Candidate, EditCandidateBioCommand, bool>
    {
        public EditCandidateBioCommandHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditCandidateBioCommand request, CancellationToken cancellationToken)
        {
            var Candidate = new Candidate
            {
                ID = request.ID,
                Bio = request.Bio,
            };

            _repository.SaveIncluded(Candidate,nameof(Candidate.Bio));

            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
