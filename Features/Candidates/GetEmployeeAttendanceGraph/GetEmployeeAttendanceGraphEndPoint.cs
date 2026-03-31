using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.GetEmployeeAttendanceGraph
{
    public class GetEmployeeAttendanceGraphEndPoint : EndpointBase<GetEmployeeAttendanceGraphRequestViewModel, GetEmployeeAttendanceGraphResponseViewModel>
    {
        public GetEmployeeAttendanceGraphEndPoint(EndpointBaseParameters<GetEmployeeAttendanceGraphRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetEmployeeAttendanceGraph })]
        public async Task<ActionResult<EndPointResponse<List<GetEmployeeAttendanceGraphResponseViewModel>>>> GetEmployeeAttendanceGraph(
         [FromBody] GetEmployeeAttendanceGraphRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetEmployeeAttendanceGraphQuery>());
            var response = result.Data.MapList<GetEmployeeAttendanceGraphResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {
                return EndPointResponse<List<GetEmployeeAttendanceGraphResponseViewModel>>
                    .Success(response.ToList(), "graph returned successfully.");
            }

            return EndPointResponse<List<GetEmployeeAttendanceGraphResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
