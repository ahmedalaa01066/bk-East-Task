using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Shifts.DTOs;
using EasyTask.Features.Common.Shifts.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Shifts.GetAllShifts
{
    public class GetAllShiftsEndpoint : EndpointBase<GetAllShiftsRequestViewModel, GetAllShiftsResponseViewModel>
    {
        public GetAllShiftsEndpoint(EndpointBaseParameters<GetAllShiftsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllShifts })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllShiftsResponseViewModel>>>> GetAllShifts(
         [FromQuery] GetAllShiftsRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllShiftsQuery>());
            var response = result.Data.MapPage<GetAllShiftsDTO, GetAllShiftsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllShiftsResponseViewModel>>
                    .Success(response, "Shifts filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllShiftsResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
