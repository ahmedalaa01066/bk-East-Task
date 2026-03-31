using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.VacationRequests.DTOs;
using EasyTask.Features.Common.VacationRequests.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.VacationRequests.GetAllVacationRequests
{
    public class GetAllVacationRequestsEndpoint : EndpointBase<GetAllVacationRequestsRequestViewModel, GetAllVacationRequestsResponseViewModel>
    {
        public GetAllVacationRequestsEndpoint(EndpointBaseParameters<GetAllVacationRequestsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllVacationRequests })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllVacationRequestsResponseViewModel>>>> GetAllVacationRequests(
        [FromQuery] GetAllVacationRequestsRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllVacationRequestsQuery>());
            var response = result.Data.MapPage<GetAllVacationRequestsDTO, GetAllVacationRequestsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllVacationRequestsResponseViewModel>>
                    .Success(response, "Employee Vacations Requests got successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllVacationRequestsResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
