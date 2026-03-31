using EasyTask.Common.Requests;
using EasyTask.Models.Candidates;

namespace EasyTask.Features.Candidates.EditCandidateManagement.Command
{
    public record EditCandidateManagementCommand(string ID,string ManagementId):IRequestBase<bool>;
    public class EditCandidateManagementCommandHandler : RequestHandlerBase<Candidate, EditCandidateManagementCommand, bool>
    {
        public EditCandidateManagementCommandHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditCandidateManagementCommand request, CancellationToken cancellationToken)
        {
            var Candidate = new Candidate
            {
                ID = request.ID,
                ManagementId = request.ManagementId
            };

            _repository.SaveIncluded(Candidate, nameof(Candidate.ManagementId));

            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
