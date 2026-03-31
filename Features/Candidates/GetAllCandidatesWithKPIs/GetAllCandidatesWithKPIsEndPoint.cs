using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.GetAllCandidatesWithKPIs
{
    public class GetAllCandidatesWithKPIsEndPoint : EndpointBase<GetAllCandidatesWithKPIsRequestViewModel, GetAllCandidatesWithKPIsResponseViewModel>
    {
        public GetAllCandidatesWithKPIsEndPoint(EndpointBaseParameters<GetAllCandidatesWithKPIsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllCandidatesWithKPIs })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllCandidatesWithKPIsResponseViewModel>>>> GetAllCandidatesWithKPIs(
         [FromQuery] GetAllCandidatesWithKPIsRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllCandidatesWithKPIsQuery>());
            var response = result.Data.MapPage<GetAllCandidatesWithKPIsDTO, GetAllCandidatesWithKPIsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllCandidatesWithKPIsResponseViewModel>>
                    .Success(response, "Candidates filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllCandidatesWithKPIsResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
