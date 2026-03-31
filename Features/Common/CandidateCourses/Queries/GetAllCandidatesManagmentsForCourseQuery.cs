using EasyTask.Common.Requests;
using EasyTask.Features.Common.Managements.DTOs;
using EasyTask.Models.CandidateCourses;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.CandidateCourses.Queries
{
    public record GetAllCandidatesManagmentsForCourseQuery(string CourseId) : IRequestBase<List<ManagementIDAndNameDTO>>;
    public class GetAllCandidatesManagmentsForCourseQueryHandler : RequestHandlerBase<CandidateCourse, GetAllCandidatesManagmentsForCourseQuery, List<ManagementIDAndNameDTO>>
    {
        public GetAllCandidatesManagmentsForCourseQueryHandler(RequestHandlerBaseParameters<CandidateCourse> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<ManagementIDAndNameDTO>>> Handle(GetAllCandidatesManagmentsForCourseQuery request, CancellationToken cancellationToken)
        {

            var model = await _repository
                .Get(c => c.CourseId == request.CourseId)
                .Include(c => c.Candidate)
                .ThenInclude(c => c.Management)
                .Where(c => c.Candidate != null && c.Candidate.Management != null)
                .Select(c => new ManagementIDAndNameDTO
                {
                    ID = c.Candidate.ManagementId,
                    Name = c.Candidate.Management.Name,
                })
                .Distinct()
                .ToListAsync();
            return RequestResult<List<ManagementIDAndNameDTO>>.Success(model);
        }
    }
}