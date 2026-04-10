using EasyTask.Common.Requests;
using EasyTask.Models.Projects;

namespace EasyTask.Features.Projects.AssignCandidatesToProject.Commands;

public record AssignCandidatesToProjectCommand(string ProjectId, List<string>? CandidateIds)
    : IRequestBase<bool>;
    
public class AssignCandidatesToProjectCommandHandler(RequestHandlerBaseParameters<CandidateProject> requestParameters)
    : RequestHandlerBase<CandidateProject, AssignCandidatesToProjectCommand, bool>(
        requestParameters)
{
    public override async Task<RequestResult<bool>> Handle(AssignCandidatesToProjectCommand request, CancellationToken cancellationToken)
    {
        var candidateProjects = (request.CandidateIds ?? [])
            .Select(candidateId => new CandidateProject
            {
                CandidateId = candidateId,
                ProjectId = request.ProjectId
            }).ToList();

        await _repository.AddRangeAsync(candidateProjects, cancellationToken);
        
        await _repository.SaveChangesAsync(cancellationToken);
        
        return RequestResult<bool>.Success(true);
    }
}