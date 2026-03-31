using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.CandidateKPIs;
using EasyTask.Models.KPIs;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.CandidateKPIs.UnassignKPIToCandidate.Commands
{
    public record UnassignKPIToCandidateCommand(string CandidateId, string KPIId) :IRequestBase<bool>;
    public class UnassignKPIToCandidateCommandHandler : RequestHandlerBase<CandidateKPI, UnassignKPIToCandidateCommand, bool>
    {
        public UnassignKPIToCandidateCommandHandler(RequestHandlerBaseParameters<CandidateKPI> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(UnassignKPIToCandidateCommand request, CancellationToken cancellationToken)
        {
            var kpi = await _repository
                          .Get(k=>k.KPIId==request.KPIId && k.CandidateId==request.CandidateId)
                          .FirstOrDefaultAsync();

            if (kpi == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            _repository.Delete(kpi);
            _repository.SaveChanges();
            return await Task.FromResult(RequestResult<bool>.Success(true));
        }
    }
}
