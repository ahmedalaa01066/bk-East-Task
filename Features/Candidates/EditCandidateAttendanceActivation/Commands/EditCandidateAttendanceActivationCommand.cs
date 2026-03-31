using EasyTask.Common.Requests;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Candidates.EditCandidateAttendanceActivation.Commands
{
    public record EditCandidateAttendanceActivationCommand(string ID, AttendanceActivation AttendanceActivation):IRequestBase<bool>;
    public class EditCandidateAttendanceActivationCommandHandler : RequestHandlerBase<Candidate, EditCandidateAttendanceActivationCommand, bool>
    {
        public EditCandidateAttendanceActivationCommandHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditCandidateAttendanceActivationCommand request, CancellationToken cancellationToken)
        {
            var Candidate = new Candidate
            {
                ID = request.ID,
                AttendanceActivation = request.AttendanceActivation,
            };

            _repository.SaveIncluded(Candidate, nameof(Candidate.AttendanceActivation));

            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
