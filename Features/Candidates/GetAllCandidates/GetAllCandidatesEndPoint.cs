using EasyTask.Common.Endpoints;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Features.Common.Candidates.Queries;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Helpers;
using EasyTask.Common.Enums;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Candidates.GetAllCandidates
{
    public class GetAllCandidatesEndPoint : EndpointBase<GetAllCandidatesRequestViewModel, GetAllCandidatesResponseViewModel>
    {
        public GetAllCandidatesEndPoint(EndpointBaseParameters<GetAllCandidatesRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllCandidates })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllCandidatesResponseViewModel>>>> GetAllCandidates(
         [FromQuery] GetAllCandidatesRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllCandidatesQuery>());
            var response = result.Data.MapPage<GetAllCandidatesDTO, GetAllCandidatesResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllCandidatesResponseViewModel>>
                    .Success(response, "Candidates filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllCandidatesResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
