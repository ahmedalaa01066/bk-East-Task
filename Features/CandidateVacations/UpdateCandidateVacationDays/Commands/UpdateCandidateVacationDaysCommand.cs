using EasyTask.Common.Requests;
using EasyTask.Models.CandidateVacations;

namespace EasyTask.Features.CandidateVacations.UpdateCandidateVacationDays.Commands
{
    public record UpdateCandidateVacationDaysCommand(string ID,int Counter) :IRequestBase<bool>;
    public class UpdateCandidateVacationDaysCommandHandler : RequestHandlerBase<CandidateVacation, UpdateCandidateVacationDaysCommand, bool>
    {
        public UpdateCandidateVacationDaysCommandHandler(RequestHandlerBaseParameters<CandidateVacation> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(UpdateCandidateVacationDaysCommand request, CancellationToken cancellationToken)
        {
            var candidateVacation = new CandidateVacation
            {
                ID = request.ID,
                Counter=request.Counter,
            };

            _repository.SaveIncluded(candidateVacation, nameof(candidateVacation.Counter));

            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
