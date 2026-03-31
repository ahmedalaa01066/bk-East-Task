using EasyTask.Common.Requests;
using EasyTask.Features.Candidates.EditCandidateManagement.Command;
using EasyTask.Features.Documents.EditDocument.Commands;
using EasyTask.Features.Managements.EditManagement.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.Managements;

namespace EasyTask.Features.Managements.EditManagement.Orchestrator
{
    public record EditManagementOrchestrator(string ID, string Name, string? ManagerId) : IRequestBase<bool>;
    public class EditManagementOrchestratorHandler : RequestHandlerBase<Management, EditManagementOrchestrator, bool>
    {
        public EditManagementOrchestratorHandler(RequestHandlerBaseParameters<Management> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditManagementOrchestrator request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request.MapOne<EditManagementCommand>());

            var EditDocument = await _mediator.Send(new EditDocumentCommand(request.Name, request.ID, DocumentType.Management));
            
            if (!EditDocument.IsSuccess)
                return RequestResult<bool>.Failure(EditDocument.ErrorCode);

            var CandidateManagementResult = await _mediator.Send(new EditCandidateManagementCommand(request.ManagerId, request.ID));
            
            if (!CandidateManagementResult.IsSuccess)
            {
                return RequestResult<bool>.Failure(CandidateManagementResult.ErrorCode);
            }
            return RequestResult<bool>.Success(true);

        }
    }
}
