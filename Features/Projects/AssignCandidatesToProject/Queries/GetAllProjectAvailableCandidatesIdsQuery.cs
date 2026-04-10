using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Project.Queries;
using EasyTask.Models.Candidates;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Projects.AssignCandidatesToProject.Queries;

public record GetAllProjectAvailableCandidatesIdsQuery(string ProjectId) : IRequestBase<List<string>>;

public class GetAllProjectAvailableCandidatesIdsQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters)
    : RequestHandlerBase<Candidate,
        GetAllProjectAvailableCandidatesIdsQuery, List<string>>(
        requestParameters)
{
    public override async Task<RequestResult<List<string>>> Handle(GetAllProjectAvailableCandidatesIdsQuery request, CancellationToken cancellationToken)
    {
        var managementAndDepartmentIdsResult = await _mediator.Send(new GetProjectManagementAndDepartmentIdsQuery(request.ProjectId),
            cancellationToken);

        if (managementAndDepartmentIdsResult.IsSuccess || 
            managementAndDepartmentIdsResult.Data?.DepartmentID is null ||
            managementAndDepartmentIdsResult.Data?.ManagementID is null)
        {
            return RequestResult<List<string>>.Failure(ErrorCode.NotFound); 
        }
        
        var managementAndDepartmentIds = managementAndDepartmentIdsResult.Data!; 
        
        var candidates = await _repository.Get(c => c.ManagementId == managementAndDepartmentIds.ManagementID &&
                                              c.DepartmentId == managementAndDepartmentIds.DepartmentID)
            .Select(c => c.ID)
            .ToListAsync(cancellationToken);
        
        return RequestResult<List<string>>.Success(candidates);
    }
}

