using EasyTask.Common.Requests;
using EasyTask.Features.Common.Attendances.DTOs;
using EasyTask.Features.Common.VacationRequests.Queries;
using EasyTask.Models.Attendances;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Attendances.Queries
{
    public record GetTodayAttendanceQuery() : IRequestBase<GetTodayAttendanceDTO>;
    public class GetTodayAttendanceQueryHandler : RequestHandlerBase<Attendance, GetTodayAttendanceQuery, GetTodayAttendanceDTO>
    {
        public GetTodayAttendanceQueryHandler(RequestHandlerBaseParameters<Attendance> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetTodayAttendanceDTO>> Handle(GetTodayAttendanceQuery request, CancellationToken cancellationToken)
        {
            int Attendance = await _repository.Get(a => DateOnly.FromDateTime(a.ActualStartDate) == DateOnly.FromDateTime(DateTime.Now)).CountAsync();
            int Annual = (await _mediator.Send(new GetTodayVacationNumberQuery())).Data;
            int WorkFromHome = (await _mediator.Send(new GetTodaySpecialVacationNumberQuery())).Data;
            var result = new GetTodayAttendanceDTO
            {
                Attendance = Attendance,
                WorkFromHome = WorkFromHome,
                Annual = Annual
            };
            return RequestResult<GetTodayAttendanceDTO>.Success(result);
        }
    }
}
