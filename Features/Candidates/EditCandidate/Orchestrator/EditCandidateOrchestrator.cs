using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Candidates.EditCandidate.Command;
using EasyTask.Features.Common.Documents.Queries;
using EasyTask.Features.Common.Medias.DTOs;
using EasyTask.Features.Common.Users.EditUser.Commands;
using EasyTask.Features.Documents.EditDocument.Commands;
using EasyTask.Features.Documents.EditParentDocumentId.Commands;
using EasyTask.Features.Medias.AttachMediaToDocument.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using Microsoft.IdentityModel.Tokens;

namespace EasyTask.Features.Candidates.EditCandidate.Orchestrator
{
    public record EditCandidateOrchestrator(
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
        string DocumentId,
        List<string>? Paths,
        string? JobId,
        Role? RoleId
    ) : IRequestBase<bool>;
    public class EditCandidateOrchestratorHandler : RequestHandlerBase<Candidate, EditCandidateOrchestrator, bool>
    {
        public EditCandidateOrchestratorHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(EditCandidateOrchestrator request, CancellationToken cancellationToken)
        {
            var departmentId = (await _repository.GetByIDAsync(request.ID)).DepartmentId;
            if (request.DepartmentId != departmentId)
            {
                var document = await _mediator.Send(new GetDocumentIdBySourceIdAndTypeQuery(request.DepartmentId, DocumentType.Department));
                var check = await _mediator.Send(new EditParentDocumentIdCommand(request.DocumentId, document.Data.ID));
                if (!check.IsSuccess)
                {
                    return RequestResult<bool>.Failure(check.ErrorCode);
                }
            }

            if (!request.PhoneNumber.IsNullOrEmpty())
            {
                var PhoneExists = await _repository.AnyAsync(c => c.PhoneNumber == request.PhoneNumber && c.ID != request.ID);

                if (PhoneExists)
                {
                    return RequestResult<bool>.Failure(ErrorCode.ExistMobile);
                }
            }

            if (!request.Email.IsNullOrEmpty())
            {
                var EmailExists = await _repository.AnyAsync(c => c.Email == request.Email && c.ID != request.ID);

                if (EmailExists)
                {
                    return RequestResult<bool>.Failure(ErrorCode.ExistEmail);
                }
            }
            var userUpdateResult = await _mediator.Send(
                       new EditUserCommand(request.ID, $"{request.FirstName} {request.LastName}", request.PhoneNumber, request.Email,request.RoleId));

            if (!userUpdateResult.IsSuccess)
                return RequestResult<bool>.Failure(userUpdateResult.ErrorCode);

            var candidateUpdateResult = await _mediator.Send(request.MapOne<EditCandidateCommand>());

            if (!candidateUpdateResult.IsSuccess)
                return RequestResult<bool>.Failure(candidateUpdateResult.ErrorCode);



            var EditDocument = await _mediator.Send(new EditDocumentCommand($"{request.FirstName} {request.LastName}", request.ID, DocumentType.Candidate));
            if (!EditDocument.IsSuccess)
                return RequestResult<bool>.Failure(EditDocument.ErrorCode);

            if (request.Paths is { Count: > 0 })
            {
                var attachMediaDtos = request.Paths
                    .Select(path => new AttachMediaToDocumentDTO(SourceType.CandidateData, path)).ToList();

                var saveMediaResult = await _mediator.Send(new AttachMediaToDocumentCommand(
                    SourceId: request.ID,
                    DocumentId: request.DocumentId,
                    AttachMediaToDocumentDTOs: attachMediaDtos
                ), cancellationToken);

                if (!saveMediaResult.IsSuccess)
                {
                    return RequestResult<bool>.Failure(saveMediaResult.ErrorCode);
                }
            }
            return RequestResult<bool>.Success(true);
        }
    }
}
