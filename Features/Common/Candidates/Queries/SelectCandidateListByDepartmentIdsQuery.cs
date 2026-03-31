using EasyTask.Common.Requests;
using EasyTask.Features.Common.CandidateCourses.Queries;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.Candidates.Queries
{
    public record SelectCandidateListByDepartmentIdsQuery(List<string>? DepartmentIds, string? CourseId) : IRequestBase<IEnumerable<SelectCandidateListByDepartmentIdsDTO>>;
    public class SelectCandidateListByDepartmentIdsQueryHandler : RequestHandlerBase<Candidate, SelectCandidateListByDepartmentIdsQuery, IEnumerable<SelectCandidateListByDepartmentIdsDTO>>
    {
        public SelectCandidateListByDepartmentIdsQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<SelectCandidateListByDepartmentIdsDTO>>> Handle(SelectCandidateListByDepartmentIdsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Candidate> query;

            if (request.DepartmentIds == null || request.DepartmentIds.Count == 0)
            {
                query = _repository.Get();
            }
            else
            {
                query = _repository.Get(c => request.DepartmentIds.Contains(c.DepartmentId));
            }

            var candidates = query.Map<SelectCandidateListByDepartmentIdsDTO>().ToList();
            if (string.IsNullOrEmpty(request.CourseId))
            {
                foreach (var candidate in candidates)
                {
                    candidate.Assignment = Assignment.Unassigned;
                }
            }
            else
            {
                var assignedResult = await _mediator.Send(new Check_AssignedCandidateQuery(request.CourseId));
                var assignedCandidateIds = assignedResult.Data.ToHashSet();

                foreach (var candidate in candidates)
                {
                    candidate.Assignment = assignedCandidateIds.Contains(candidate.ID)
                        ? Assignment.Assigned
                        : Assignment.Unassigned;
                }
            }

            return RequestResult<IEnumerable<SelectCandidateListByDepartmentIdsDTO>>.Success(candidates);
        }
    }
}
