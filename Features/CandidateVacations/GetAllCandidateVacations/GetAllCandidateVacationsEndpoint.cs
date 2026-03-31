using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.CandidateVacations.DTOs;
using EasyTask.Features.Common.CandidateVacations.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidateVacations.GetAllCandidateVacations
{
    public class GetAllCandidateVacationsEndpoint : EndpointBase<GetAllCandidateVacationsRequestViewModel, GetAllCandidateVacationsResponseViewModel>
    {
        public GetAllCandidateVacationsEndpoint(EndpointBaseParameters<GetAllCandidateVacationsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllCandidatesVacations })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllCandidateVacationsResponseViewModel>>>> GetAllCandidatesVacations(
            [FromQuery] GetAllCandidateVacationsRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllCandidateVacationsQuery>());
            var response = result.Data.MapPage<GetAllCandidateVacationsDTO, GetAllCandidateVacationsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllCandidateVacationsResponseViewModel>>
                    .Success(response, "Candidates Vacations filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllCandidateVacationsResponseViewModel>>
                .Failure(ErrorCode.NotFound);

        }
    }
}