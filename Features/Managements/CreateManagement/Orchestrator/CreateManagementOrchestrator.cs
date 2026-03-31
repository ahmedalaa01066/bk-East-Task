using EasyTask.Common.Requests;
using EasyTask.Features.Candidates.EditCandidateManagement.Command;
using EasyTask.Features.Common.Documents.Queries;
using EasyTask.Features.Departments.CreateDepartment.Commands;
using EasyTask.Features.Documents.AddDocument.Commands;
using EasyTask.Features.Documents.EditParentDocumentId.Commands;
using EasyTask.Features.Managements.CreateManagement.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.Managements;

namespace EasyTask.Features.Managements.CreateManagement.Orchestrator
{
    public record CreateManagementOrchestrator(string Name, string ManagerId, List<string> DepartmentName):IRequestBase<bool>;
    public class CreateManagementOrchestratorHandler : RequestHandlerBase<Management, CreateManagementOrchestrator, bool>
    {
        public CreateManagementOrchestratorHandler(RequestHandlerBaseParameters<Management> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateManagementOrchestrator request, CancellationToken cancellationToken)
        {
            var management = await _mediator.Send(request.MapOne<CreateManagementCommand>());
            if (!management.IsSuccess)
            {
                return RequestResult<bool>.Failure(management.ErrorCode);
            }
            var managementId = management.Data;
            

            var managementDocumentResult = await _mediator.Send(new AddDocumentCommand(
                PhysicalName: request.Name,
                SourceId: managementId,
                SourceType: DocumentType.Management,
                Path: "Managements",
                ParentDocumentId: null));

            if (!managementDocumentResult.IsSuccess)
                return RequestResult<bool>.Failure(managementDocumentResult.ErrorCode);

            foreach (var departmentName in request.DepartmentName)
            {
                var departmentResult = await _mediator.Send(new CreateDepartmentCommand(departmentName, managementId,request.Name));
                if (!departmentResult.IsSuccess)
                {
                    return RequestResult<bool>.Failure(departmentResult.ErrorCode);
                }
                
                var createDepartmentFolderCommand = new AddDocumentCommand(
                    PhysicalName: departmentName,
                    SourceId: departmentResult.Data,
                    SourceType: DocumentType.Department,
                    Path: "Departments",
                    ParentDocumentId: managementDocumentResult.Data.ID
                    );

                var departmentDocumentResult = await _mediator.Send(createDepartmentFolderCommand);
                if (!departmentDocumentResult.IsSuccess)
                {
                    return RequestResult<bool>.Failure(departmentDocumentResult.ErrorCode);
                }
            }

            var CandidateManagementResult = await _mediator.Send(new EditCandidateManagementCommand(request.ManagerId,managementId));
            if (!CandidateManagementResult.IsSuccess)
            {
                return RequestResult<bool>.Failure(CandidateManagementResult.ErrorCode);
            }

            var document = await _mediator.Send(new GetDocumentIdBySourceIdAndTypeQuery(request.ManagerId, DocumentType.Candidate));
            var ManagerDocument = await _mediator.Send(new EditParentDocumentIdCommand(document.Data.ID, managementDocumentResult.Data.ID));
            return RequestResult<bool>.Success(true);
        }
    }
}
