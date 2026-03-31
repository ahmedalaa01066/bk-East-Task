using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Attendances.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Attendances;

namespace EasyTask.Features.Common.Attendances.Queries
{
    public record GetShiftAndPauseDurationByIDQuery(string AttendanceId):IRequestBase<GetShiftAndPauseDurationByIDDTO>;
    public class GetShiftAndPauseDurationByIDQueryHandler : RequestHandlerBase<Attendance, GetShiftAndPauseDurationByIDQuery, GetShiftAndPauseDurationByIDDTO>
    {
        public GetShiftAndPauseDurationByIDQueryHandler(RequestHandlerBaseParameters<Attendance> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetShiftAndPauseDurationByIDDTO>> Handle(GetShiftAndPauseDurationByIDQuery request, CancellationToken cancellationToken)
        {
            var attendance = await _repository.GetByIDAsync(request.AttendanceId);
            if (attendance==null)
            {
                return RequestResult<GetShiftAndPauseDurationByIDDTO>.Failure(ErrorCode.NotFound);
            }
            var response = attendance.MapOne<GetShiftAndPauseDurationByIDDTO>();
            return RequestResult<GetShiftAndPauseDurationByIDDTO>.Success(response);
        }
    }
}
