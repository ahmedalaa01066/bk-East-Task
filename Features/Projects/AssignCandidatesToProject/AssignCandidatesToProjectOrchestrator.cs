using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Projects.AssignCandidatesToProject.Commands;
using EasyTask.Features.Projects.AssignCandidatesToProject.Queries;
using EasyTask.Models.Projects;

namespace EasyTask.Features.Projects.AssignCandidatesToProject;

public record AssignCandidatesToProjectOrchestrator(string ProjectId, List<string>? CandidateIds)
    : IRequestBase<AssignCandidatesToProjectResponseVm>;

public class AssignCandidatesToProjectOrchestratorHandler(
    RequestHandlerBaseParameters<CandidateProject> requestParameters)
    : RequestHandlerBase<CandidateProject, AssignCandidatesToProjectOrchestrator, AssignCandidatesToProjectResponseVm>(
        requestParameters)
{
    public override async Task<RequestResult<AssignCandidatesToProjectResponseVm>> Handle(
        AssignCandidatesToProjectOrchestrator request, CancellationToken cancellationToken)
    {
        var allProjectAvailableCandidates =
            await _mediator.Send(new GetAllProjectAvailableCandidatesIdsQuery(request.ProjectId),
                cancellationToken);


        var canCandidateCanBeAssignedToProjectValidationResult =
            ValidateCandidateCanBeAssignedToProject(request.CandidateIds, allProjectAvailableCandidates.Data);
        if (!canCandidateCanBeAssignedToProjectValidationResult.IsSuccess)
        {
            return canCandidateCanBeAssignedToProjectValidationResult;
        }

        var assignationResult = await _mediator.Send(new AssignCandidatesToProjectCommand(request.ProjectId, request.CandidateIds), cancellationToken);
        
        return assignationResult.IsSuccess
            ? RequestResult<AssignCandidatesToProjectResponseVm>.Success(new AssignCandidatesToProjectResponseVm(), "Candidates assigned to project")
            : RequestResult<AssignCandidatesToProjectResponseVm>.Failure(assignationResult.ErrorCode);
    }
    

    private RequestResult<AssignCandidatesToProjectResponseVm> ValidateCandidateCanBeAssignedToProject(
        List<string>? requestCandidateIds,
        List<string>? availableCandidateIds)
    {
        if (requestCandidateIds is null || requestCandidateIds.Count == 0)
        {
            return RequestResult<AssignCandidatesToProjectResponseVm>.Failure(ErrorCode.NoCandidateIdsProvided);
        }

        if (availableCandidateIds is null || availableCandidateIds.Count == 0)
        {
            return RequestResult<AssignCandidatesToProjectResponseVm>.Failure(ErrorCode.NoAvailableCandidatesForProject);
        }

        var availableSet = new HashSet<string>(availableCandidateIds);

        var isThereInvalidCandidate = requestCandidateIds
            .Where(id => !availableSet.Contains(id))
            .Distinct()
            .Any();

        if (isThereInvalidCandidate)
        {
            return RequestResult<AssignCandidatesToProjectResponseVm>.Failure(ErrorCode.SomeCandidatesCannotBeAssignedToProject);
        }

        return RequestResult<AssignCandidatesToProjectResponseVm>.Success();
    }
}