using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Vacations.DTOs;
using EasyTask.Features.Common.Vacations.Queries;
using EasyTask.Features.Common.Shifts.DTOs;
using EasyTask.Features.Common.Shifts.Queries;
using EasyTask.Features.Shifts.GetAllShifts;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Vacations.GetAllVacations
{
    public class GetAllVacationsEndpoint : EndpointBase<GetAllVacationsRequestViewModel, GetAllVacationsResponseViewModel>
    {
        public GetAllVacationsEndpoint(EndpointBaseParameters<GetAllVacationsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllVacations })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllVacationsResponseViewModel>>>> GetAllVacations(
        [FromQuery] GetAllVacationsRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllVacationsQuery>());
            var response = result.Data.MapPage<GetAllVacationsDTO, GetAllVacationsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllVacationsResponseViewModel>>
                    .Success(response, "Employee Vacations filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllVacationsResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
