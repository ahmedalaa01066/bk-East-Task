using EasyTask.Common.Requests;
using EasyTask.Models.Projects;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Projects.GetAllProjectCandidates.Queries;

public record GetAllProjectCandidatesQuery(string ProjectId) : IRequestBase<List<GetAllProjectCandidatesResponseVm>>;

public class GetAllProjectCandidatesQueryHandler(RequestHandlerBaseParameters<Project> requestParameters)
    : RequestHandlerBase<Project,
        GetAllProjectCandidatesQuery, List<GetAllProjectCandidatesResponseVm>>(
        requestParameters)
{
    public override async Task<RequestResult<List<GetAllProjectCandidatesResponseVm>>> Handle(GetAllProjectCandidatesQuery request, CancellationToken cancellationToken)
    {
        // Select all candidates that belong to the project and project them to the response VM.
        var candidates = await _repository.Get(p => p.ID == request.ProjectId)
            // flatten candidate-project relation into candidate entities
            .SelectMany(p => p.Candidates.Select(cp => cp.Candidate))
            // map to response vm, use empty string fallback for nullable navigation names
            .Select(c => new GetAllProjectCandidatesResponseVm
            {
                Id = c.ID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                DepartmentID = c.DepartmentId,
                DepartmentName = c.Department != null ? c.Department.Name : string.Empty,
                ManagementID = c.ManagementId,
                ManagementName = c.Management != null ? c.Management.Name : string.Empty
            })
            .ToListAsync(cancellationToken);

        return RequestResult<List<GetAllProjectCandidatesResponseVm>>.Success(candidates);
    }
}

