using EasyTask.Common.Requests;
using EasyTask.Models.CandidateKPIs;

namespace EasyTask.Features.CandidateKPIs.AssignKPIToCandidate.Commands
{
    public record AssignKPIToCandidateCommand(string CandidateId, string KPIId, double Percentage) : IRequestBase<bool>;
    public class AssignKPIToCandidateCommandHandler : RequestHandlerBase<CandidateKPI, AssignKPIToCandidateCommand, bool>
    {
        public AssignKPIToCandidateCommandHandler(RequestHandlerBaseParameters<CandidateKPI> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AssignKPIToCandidateCommand request, CancellationToken cancellationToken)
        {
            CandidateKPI candidateKPI = new CandidateKPI
            {
                CandidateId = request.CandidateId,
                KPIId = request.KPIId,
                Percentage = request.Percentage
            };
            _repository.Add(candidateKPI);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
