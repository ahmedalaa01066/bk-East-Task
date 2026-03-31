using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Features.Common.Attendances.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Attendances.GetAttendanceCircle
{
    public class GetAttendanceCircleEndPoint : EndpointBase<GetAttendanceCircleRequestViewModel, GetAttendanceCircleResponseViewModel>
    {
        public GetAttendanceCircleEndPoint(EndpointBaseParameters<GetAttendanceCircleRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAttendanceCircle })]
        public async Task<ActionResult<EndPointResponse<GetAttendanceCircleResponseViewModel>>> GetAttendanceCircle(
         [FromQuery] GetAttendanceCircleRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAttendanceCircleQuery>());
            var response = result.Data.MapOne<GetAttendanceCircleResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<GetAttendanceCircleResponseViewModel>
                    .Success(response, "Attendances Circle Got successfully.");
            }

            return EndPointResponse<GetAttendanceCircleResponseViewModel>
                .Failure(result.ErrorCode);
        }
    }
}
