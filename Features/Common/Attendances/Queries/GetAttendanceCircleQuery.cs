using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Attendances.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Attendances;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Attendances.Queries
{
    public record GetAttendanceCircleQuery(string CandidateId) : IRequestBase<GetAttendanceCircleDTO>;
    public class GetAttendanceCircleQueryHandler : RequestHandlerBase<Attendance, GetAttendanceCircleQuery, GetAttendanceCircleDTO>
    {
        public GetAttendanceCircleQueryHandler(RequestHandlerBaseParameters<Attendance> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetAttendanceCircleDTO>> Handle(GetAttendanceCircleQuery request, CancellationToken cancellationToken)
        {
            var today = DateTime.Now.Date;

            var model = _repository
                .Get(a => a.CandidateId == request.CandidateId && a.ActualStartDate.Date == today.Date)
                .Include(a => a.Shift)
                .FirstOrDefault();
            if (model == null)
            {
                return RequestResult<GetAttendanceCircleDTO>.Failure(ErrorCode.AttendanceNotFoundForToday);
            }
            var dto = model.MapOne<GetAttendanceCircleDTO>();

            return RequestResult<GetAttendanceCircleDTO>.Success(dto);
        }
    }
}
