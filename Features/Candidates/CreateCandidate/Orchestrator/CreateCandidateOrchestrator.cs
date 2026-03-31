using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.CandidateKPIs.AssignKPIToCandidate.Orchestrators;
using EasyTask.Features.Candidates.CreateCandidate.Commands;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Features.Common.DefaultKPIs.Queries;
using EasyTask.Features.Common.Documents.Queries;
using EasyTask.Features.Common.Users.CreateUser.Commands;
using EasyTask.Features.Documents.AddDocument.Commands;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using Microsoft.IdentityModel.Tokens;

namespace EasyTask.Features.Candidates.CreateCandidate.Orchestrator
{
    public record CreateCandidateOrchestrator(
    string FirstName,
    string LastName,
    string Password,
    string ConfirmPassword,
    DateOnly JoiningDate,
    string Email,
    string PhoneNumber,
    CandidateStatus CandidateStatus,
    string? ManagerId,
    string? ManagementId,
    string? DepartmentId,
    string LevelId,
    string PositionId,
    string? PositionName,
    //string? CandidateImage,
    //List<string>? Paths,
    string? Bio,
     string? JobId,
     Role RoleId
    ) : IRequestBase<CreateCandidateDTO>;
    public class CreateCandidateOrchestratorHandler : RequestHandlerBase<Candidate, CreateCandidateOrchestrator, CreateCandidateDTO>
    {
        public CreateCandidateOrchestratorHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<CreateCandidateDTO>> Handle(CreateCandidateOrchestrator request, CancellationToken cancellationToken)
        {
            var phoneExists = await _repository.AnyAsync(c => c.PhoneNumber == request.PhoneNumber);
            if (phoneExists)
            {
                return RequestResult<CreateCandidateDTO>.Failure(ErrorCode.ExistMobile);
            }
            var EmailExists = await _repository.AnyAsync(c => c.Email == request.Email);
            if (EmailExists)
            {
                return RequestResult<CreateCandidateDTO>.Failure(ErrorCode.ExistEmail);
            }

            var userIdResult = await _mediator.Send(new CreateUserCommand(
                Name: $"{request.FirstName} {request.LastName}",
                Password: request.Password,
                ConfirmPassword: request.ConfirmPassword,
                Email: request.Email,
                Mobile: request.PhoneNumber,
                RoleId: request.RoleId,
                VerifyStatus: VerifyStatus.Verified
            ));

            if (!userIdResult.IsSuccess)
            {
                return RequestResult<CreateCandidateDTO>.Failure(userIdResult.ErrorCode);
            }

            var candidateResult = await _mediator.Send(new CreateCandidateCommand(
                ID: userIdResult.Data,
                FirstName: request.FirstName,
                LastName: request.LastName,
                JoiningDate: request.JoiningDate,
                Email: request.Email,
                PhoneNumber: request.PhoneNumber,
                CandidateStatus: request.CandidateStatus,
                ManagerId: request.ManagerId,
                ManagementId: request.ManagementId,
                DepartmentId: request.DepartmentId,
                LevelId: request.LevelId,
                PositionId: request.PositionId,
                PositionName: request.PositionName,
                Password: request.Password,
                ConfirmPassword: request.ConfirmPassword,
                Bio: request.Bio,
                JobId: request.JobId
             ));

            if (!candidateResult.IsSuccess)
            {
                return RequestResult<CreateCandidateDTO>.Failure(candidateResult.ErrorCode);
            }
            string? parentDocumentId = null;

            if (!request.DepartmentId.IsNullOrEmpty() && !request.ManagementId.IsNullOrEmpty())
            {
                var document = await _mediator.Send(new GetDocumentIdBySourceIdAndTypeQuery(request.DepartmentId, DocumentType.Department));
                parentDocumentId = document.Data.ID;
            }

            var createFolderCommand = new AddDocumentCommand(
                PhysicalName: $"{request.FirstName} {request.LastName}",
                SourceId: userIdResult.Data,
                SourceType: DocumentType.Candidate,
                Path: "Candidates",
                ParentDocumentId: parentDocumentId
            );

            var documentResult = await _mediator.Send(createFolderCommand);

            if (!documentResult.IsSuccess)
                return RequestResult<CreateCandidateDTO>.Failure(documentResult.ErrorCode);

            var resultDTO = new CreateCandidateDTO(userIdResult.Data, documentResult.Data.Path, documentResult.Data.ID);

            var DefaultKPIs = await _mediator.Send(new GetAllDefaultKPIsQuery(null, null, null));

            foreach (var kpi in DefaultKPIs.Data)
            {
                var checkAssign = await _mediator.Send(new AssignKPIToCandidateOrchestrator(kpi.Name, kpi.Type, userIdResult.Data, kpi.Percentage));
                if (!checkAssign.IsSuccess)
                {
                    return RequestResult<CreateCandidateDTO>.Failure(checkAssign.ErrorCode);
                }
            }
            return RequestResult<CreateCandidateDTO>.Success(resultDTO);

        }

    }
}
