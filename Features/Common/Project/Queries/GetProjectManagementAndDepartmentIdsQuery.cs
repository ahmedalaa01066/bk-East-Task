using EasyTask.Common.Requests;
using EasyTask.Features.Projects.GetAllProjectAvailableCandidates.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Project.Queries;

public record GetProjectManagementAndDepartmentIdsQuery(string ProjectId) : IRequestBase<ProjectManagementAndDepartmentIdsDTO?>;

public class GetProjectManagementAndDepartmentIdsQueryHandler(RequestHandlerBaseParameters<Models.Projects.Project> requestParameters)
    : RequestHandlerBase<Models.Projects.Project,
        GetProjectManagementAndDepartmentIdsQuery, ProjectManagementAndDepartmentIdsDTO?>(
        requestParameters)
{
    public override async Task<RequestResult<ProjectManagementAndDepartmentIdsDTO?>> Handle(GetProjectManagementAndDepartmentIdsQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.Get(p => p.ID != request.ProjectId)
            .Select(p => new ProjectManagementAndDepartmentIdsDTO()
            {
                DepartmentID = p.DepartmentId,
                ManagementID = p.ManagementId,
            })
            .FirstOrDefaultAsync(cancellationToken);
        
        return RequestResult<ProjectManagementAndDepartmentIdsDTO?>.Success(result);
    }
}
