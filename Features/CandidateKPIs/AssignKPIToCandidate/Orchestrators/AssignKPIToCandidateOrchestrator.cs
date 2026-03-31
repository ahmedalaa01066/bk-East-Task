using EasyTask.Common.Requests;
using EasyTask.Features.CandidateKPIs.AssignKPIToCandidate.Commands;
using EasyTask.Features.KPIs.CreateKPI.Commands;
using EasyTask.Helpers;
using EasyTask.Models.CandidateKPIs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.CandidateKPIs.AssignKPIToCandidate.Orchestrators
{
    public record AssignKPIToCandidateOrchestrator(string Name, KPIType Type, string CandidateId, double Percentage) : IRequestBase<bool>;
    public class AssignKPIToCandidateOrchestratorHandler : RequestHandlerBase<CandidateKPI, AssignKPIToCandidateOrchestrator, bool>
    {
        public AssignKPIToCandidateOrchestratorHandler(RequestHandlerBaseParameters<CandidateKPI> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AssignKPIToCandidateOrchestrator request, CancellationToken cancellationToken)
        {
            var KPIId = await _mediator.Send(request.MapOne<CreateKPICommand>());
            if (!KPIId.IsSuccess)
                return RequestResult<bool>.Failure(KPIId.ErrorCode);
            var result = await _mediator.Send(new AssignKPIToCandidateCommand(request.CandidateId, KPIId.Data, request.Percentage));
            if (!result.IsSuccess)
                return RequestResult<bool>.Failure(result.ErrorCode);
            return RequestResult<bool>.Success(true);
        }
    }
}
