using EasyTask.Common.Requests;
using EasyTask.Models.Attendances;

namespace EasyTask.Features.Common.Attendances.Queries
{
    public record GetTodayCandidateAttendance(string CandidateId,string ShiftId) : IRequestBase<string>;
    public class GetTodayCandidateAttendanceHandler : RequestHandlerBase<Attendance, GetTodayCandidateAttendance, string>
    {
        public GetTodayCandidateAttendanceHandler(RequestHandlerBaseParameters<Attendance> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(GetTodayCandidateAttendance request, CancellationToken cancellationToken)
        {

            var today = DateTime.Now.Date;

            var attendance = _repository
                .Get(a => a.CandidateId == request.CandidateId && a.ShiftId == request.ShiftId && a.ActualStartDate.Date == today)
                .FirstOrDefault();

            if (attendance == null)
                return RequestResult<string>.Success(null);

            return RequestResult<string>.Success(attendance.ID);
        }
    }
}
