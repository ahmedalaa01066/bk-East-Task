using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Attendances;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Attendances.Queries
{
    public record GetAttendanceIdByDateAndCandidateIdQuery(string candidateId) : IRequestBase<string>;
    public class GetAttendanceIdByDateAndCandidateIdQueryHandler : RequestHandlerBase<Attendance, GetAttendanceIdByDateAndCandidateIdQuery, string>
    {
        public GetAttendanceIdByDateAndCandidateIdQueryHandler(RequestHandlerBaseParameters<Attendance> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(GetAttendanceIdByDateAndCandidateIdQuery request, CancellationToken cancellationToken)
        {
            var attendance = await _repository.Get(a => a.CandidateId == request.candidateId &&
            (DateOnly.FromDateTime(a.ActualStartDate.Date) == DateOnly.FromDateTime(DateTime.Now) ||
            DateOnly.FromDateTime(a.PlannedEndDate.Date) == DateOnly.FromDateTime(DateTime.Now))).FirstOrDefaultAsync();
            if (attendance == null)
                return RequestResult<string>.Failure(ErrorCode.NotFound);
            return RequestResult<string>.Success(attendance.ID);

        }
    }
}
