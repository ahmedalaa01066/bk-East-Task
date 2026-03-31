using EasyTask.Common.Requests;
using EasyTask.Features.Common.CandidateCourses.Queries;
using EasyTask.Features.Common.Managements.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.Managements;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Managements.Queries
{
    public record SelectManagementListByCourseIdQuery(string? CourseId) : IRequestBase<IEnumerable<SelectManagementListByCourseIdDTO>>;
    public class SelectManagementListByCourseIdQueryHandler : RequestHandlerBase<Management, SelectManagementListByCourseIdQuery, IEnumerable<SelectManagementListByCourseIdDTO>>
    {
        public SelectManagementListByCourseIdQueryHandler(RequestHandlerBaseParameters<Management> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectManagementListByCourseIdDTO>>> Handle(SelectManagementListByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var managementEntities = await _repository.Get()
                .Include(m => m.Candidates)
                .ToListAsync(cancellationToken);

            var managementDtos = managementEntities
                .AsQueryable()
                .Map<SelectManagementListByCourseIdDTO>()
                .ToList();

            if (string.IsNullOrEmpty(request.CourseId))
            {
                foreach (var dto in managementDtos)
                {
                    dto.Assignment = Assignment.Unassigned;
                }
            }
            else
            {
                var assignedResult = await _mediator.Send(new Check_AssignedCandidateQuery(request.CourseId), cancellationToken);
                var assignedIds = assignedResult.Data?.ToHashSet() ?? new HashSet<string>();

                foreach (var managementEntity in managementEntities)
                {
                    var candidateIds = managementEntity.Candidates?.Select(c => c.ID).ToList() ?? new List<string>();
                    var assignedCount = candidateIds.Count(id => assignedIds.Contains(id));

                    var dto = managementDtos.First(d => d.ID == managementEntity.ID);

                    dto.Assignment = candidateIds.Count switch
                    {
                        0 => Assignment.Unassigned,
                        _ when assignedCount == 0 => Assignment.Unassigned,
                        _ when assignedCount == candidateIds.Count => Assignment.Assigned,
                        _ => Assignment.PartiallyAssigned
                    };
                }
            }

            return RequestResult<IEnumerable<SelectManagementListByCourseIdDTO>>.Success(managementDtos);


        }
    }
}
