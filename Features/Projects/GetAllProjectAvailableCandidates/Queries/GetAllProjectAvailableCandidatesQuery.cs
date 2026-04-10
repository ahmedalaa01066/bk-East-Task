using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Project.Queries;
using EasyTask.Models.Candidates;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Projects.GetAllProjectAvailableCandidates.Queries;

public record GetAllProjectAvailableCandidatesQuery(string ProjectId) : IRequestBase<List<GetAllProjectAvailableCandidatesResponseViewModel>>;

public class GetAllProjectAvailableCandidatesQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters)
    : RequestHandlerBase<Candidate,
        GetAllProjectAvailableCandidatesQuery, List<GetAllProjectAvailableCandidatesResponseViewModel>>(
        requestParameters)
{
    public override async Task<RequestResult<List<GetAllProjectAvailableCandidatesResponseViewModel>>> Handle(GetAllProjectAvailableCandidatesQuery request, CancellationToken cancellationToken)
    {
        var managementAndDepartmentIdsResult = await _mediator.Send(new GetProjectManagementAndDepartmentIdsQuery(request.ProjectId),
            cancellationToken);

        if (managementAndDepartmentIdsResult.IsSuccess || 
            managementAndDepartmentIdsResult.Data?.DepartmentID is null ||
            managementAndDepartmentIdsResult.Data?.ManagementID is null)
        {
            return RequestResult<List<GetAllProjectAvailableCandidatesResponseViewModel>>.Failure(ErrorCode.NotFound); 
        }
        
        var managementAndDepartmentIds = managementAndDepartmentIdsResult.Data!; 
        
        var candidates = await _repository.Get(c => c.ManagementId == managementAndDepartmentIds.ManagementID &&
                                              c.DepartmentId == managementAndDepartmentIds.DepartmentID)
            .Select(c => new GetAllProjectAvailableCandidatesResponseViewModel
            {
                Id = c.ID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                ManagementID = c.ManagementId,
                ManagementName = c.Management != null ? c.Management.Name : string.Empty,
                DepartmentID = c.DepartmentId,
                DepartmentName = c.Department != null ? c.Department.Name : string.Empty,
            })
            .ToListAsync(cancellationToken);
        
        return RequestResult<List<GetAllProjectAvailableCandidatesResponseViewModel>>.Success(candidates);
    }
}

