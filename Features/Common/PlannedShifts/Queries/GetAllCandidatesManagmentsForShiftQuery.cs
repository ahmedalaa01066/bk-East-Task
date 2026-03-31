using EasyTask.Common.Requests;
using EasyTask.Models.PlannedShifts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.PlannedShifts.Queries
{
    public record GetAllCandidatesManagmentsForShiftQuery(string ShiftId):IRequestBase<List<string>>;
    public class GetAllCandidatesManagmentsForShiftQueryHandler : RequestHandlerBase<PlannedShift, GetAllCandidatesManagmentsForShiftQuery, List<string>>
    {
        public GetAllCandidatesManagmentsForShiftQueryHandler(RequestHandlerBaseParameters<PlannedShift> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<string>>> Handle(GetAllCandidatesManagmentsForShiftQuery request, CancellationToken cancellationToken)
        {
            var managements = await _repository.Get(ps => ps.ShiftId == request.ShiftId)
                                               .Include(ps => ps.Candidate)
                                               .ThenInclude(c => c.Management).Select(ps => ps.Candidate.Management.Name)
                                               .Distinct().ToListAsync(cancellationToken);
            return RequestResult<List<string>>.Success(managements);
        }
    }
}
