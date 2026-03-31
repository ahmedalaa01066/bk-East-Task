using EasyTask.Common.Requests;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Candidates.EditCandidate.Command
{
    public record EditCandidateCommand(
         string ID,
        string FirstName,
        string LastName,
        DateOnly JoiningDate,
        string Email,
        string? Bio,
        string PhoneNumber,
        CandidateStatus CandidateStatus,
        string? ManagerId,
        string? ManagementId,
        string? DepartmentId,
        string LevelId,
        string PositionId,
        string? PositionName,
        string? JobId
    ) : IRequestBase<bool>;

    public class EditCandidateCommandHandler : RequestHandlerBase<Candidate, EditCandidateCommand, bool>
    {
        public EditCandidateCommandHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditCandidateCommand request, CancellationToken cancellationToken)
        {
            var Candidate = new Candidate
            {
                ID = request.ID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                JoiningDate = request.JoiningDate,
                Bio = request.Bio,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                CandidateStatus = request.CandidateStatus,
                ManagerId = request.ManagerId,
                ManagementId = request.ManagementId,
                DepartmentId = request.DepartmentId,
                LevelId = request.LevelId,
                PositionId = request.PositionId,
                PositionName = request.PositionName,
                JobId = request.JobId
            };

            _repository.SaveIncluded(Candidate, nameof(Candidate.FirstName), nameof(Candidate.LastName),
                nameof(Candidate.Email), nameof(Candidate.JoiningDate), nameof(Candidate.Bio), nameof(Candidate.PhoneNumber),
                nameof(Candidate.CandidateStatus), nameof(Candidate.ManagerId), nameof(Candidate.ManagementId), nameof(Candidate.DepartmentId),
                nameof(Candidate.LevelId), nameof(Candidate.PositionId), nameof(Candidate.JobId), nameof(Candidate.PositionName));

            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
