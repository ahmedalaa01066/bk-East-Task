using EasyTask.Common.Requests;
using EasyTask.Features.Common.CandidateCourses.Queries;
using EasyTask.Features.Common.Departments.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Departments;
using EasyTask.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Departments.Queries
{
    public record SelectDepartmentListByManagementIdsQuery(List<string>? ManagementIds, string? CourseId) : IRequestBase<IEnumerable<SelectDepartmentListByManagementIdsDTO>>;
    public class SelectDepartmentListByManagementIdsQueryHandler : RequestHandlerBase<Department, SelectDepartmentListByManagementIdsQuery, IEnumerable<SelectDepartmentListByManagementIdsDTO>>
    {
        public SelectDepartmentListByManagementIdsQueryHandler(RequestHandlerBaseParameters<Department> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectDepartmentListByManagementIdsDTO>>> Handle(SelectDepartmentListByManagementIdsQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Get();

            if (request.ManagementIds?.Count > 0)
            {
                query = _repository.Get(d => request.ManagementIds.Contains(d.ManagementId));
            }

            var departmentsWithCandidates = await query
           .Include(d => d.Candidates)
           .ToListAsync(cancellationToken);


            var departmentDtos = departmentsWithCandidates
                .AsQueryable()
                .Map<SelectDepartmentListByManagementIdsDTO>()
                .ToList();

            if (string.IsNullOrEmpty(request.CourseId))
            {
                foreach (var dto in departmentDtos)
                {
                    dto.Assignment = Assignment.Unassigned;
                }
            }
            else
            {
                var assignedResult = await _mediator.Send(new Check_AssignedCandidateQuery(request.CourseId), cancellationToken);
                var assignedIds = assignedResult.Data?.ToHashSet() ?? new HashSet<string>();

                foreach (var dept in departmentsWithCandidates)
                {
                    var candidateIds = dept.Candidates?.Select(c => c.ID).ToList() ?? new List<string>();
                    var assignedCount = candidateIds.Count(id => assignedIds.Contains(id));

                    var dto = departmentDtos.First(d => d.ID == dept.ID);

                    dto.Assignment = candidateIds.Count switch
                    {
                        0 => Assignment.Unassigned,
                        _ when assignedCount == 0 => Assignment.Unassigned,
                        _ when assignedCount == candidateIds.Count => Assignment.Assigned,
                        _ => Assignment.PartiallyAssigned
                    };
                }
            }

            return RequestResult<IEnumerable<SelectDepartmentListByManagementIdsDTO>>.Success(departmentDtos);
        }

    }
}
