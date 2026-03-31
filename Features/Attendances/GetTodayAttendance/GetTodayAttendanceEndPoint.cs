using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Attendances.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Attendances.GetTodayAttendance
{
    public class GetTodayAttendanceEndPoint : EndpointBase<GetTodayAttendanceRequestViewModel, GetTodayAttendanceResponseViewModel>
    {
        public GetTodayAttendanceEndPoint(EndpointBaseParameters<GetTodayAttendanceRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetTodayAttendance })]
        public async Task<ActionResult<EndPointResponse<GetTodayAttendanceResponseViewModel>>> GetTodayAttendance(
         [FromQuery] GetTodayAttendanceRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetTodayAttendanceQuery>());
            var response = result.Data.MapOne<GetTodayAttendanceResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<GetTodayAttendanceResponseViewModel>
                    .Success(response, "Today Attendance Got successfully.");
            }

            return EndPointResponse<GetTodayAttendanceResponseViewModel>
                .Failure(result.ErrorCode);
        }
    }
}
