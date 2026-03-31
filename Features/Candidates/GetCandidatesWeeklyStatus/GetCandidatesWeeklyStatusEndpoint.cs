using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.GetCandidatesWeeklyStatus
{
    public class GetCandidatesWeeklyStatusEndpoint : EndpointBase<GetCandidatesWeeklyStatusRequestViewModel, GetCandidatesWeeklyStatusResponseViewModel>
    {
        public GetCandidatesWeeklyStatusEndpoint(EndpointBaseParameters<GetCandidatesWeeklyStatusRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllCandidatesWeeklyStatus })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetCandidatesWeeklyStatusResponseViewModel>>>> GetAllCandidatesWeeklyStatus(
         [FromQuery] GetCandidatesWeeklyStatusRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetCandidatesWeeklyStatusQuery>());
            var response = result.Data.MapPage<GetCandidatesWeeklyStatusDTO, GetCandidatesWeeklyStatusResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetCandidatesWeeklyStatusResponseViewModel>>
                    .Success(response, "Candidates Weekly Status filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetCandidatesWeeklyStatusResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
