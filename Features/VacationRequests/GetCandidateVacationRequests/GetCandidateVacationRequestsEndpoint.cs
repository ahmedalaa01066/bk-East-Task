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

namespace EasyTask.Features.VacationRequests.GetCandidateVacationRequests
{
    public class GetCandidateVacationRequestsEndpoint : EndpointBase<GetCandidateVacationRequestsRequestViewModel, GetCandidateVacationRequestsResponseViewModel>
    {
        public GetCandidateVacationRequestsEndpoint(EndpointBaseParameters<GetCandidateVacationRequestsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetCandidateVacationRequests })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetCandidateVacationRequestsResponseViewModel>>>> GetCandidateVacationRequests(
        [FromQuery] GetCandidateVacationRequestsRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetCandidateVacationRequestsQuery>());
            var response = result.Data.MapPage<GetCandidateVacationRequestsDTO, GetCandidateVacationRequestsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetCandidateVacationRequestsResponseViewModel>>
                    .Success(response, "Employee Vacations Requests got successfully.");
            }

            return EndPointResponse<PagingViewModel<GetCandidateVacationRequestsResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
