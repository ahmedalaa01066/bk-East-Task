using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Attendances.DTOs;
using EasyTask.Features.Common.Attendances.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Attendances.GetAllAttendancesForCandidate
{
    public class GetAllAttendancesForCandidateEndPoint : EndpointBase<GetAllAttendancesForCandidateRequestViewModel, GetAllAttendancesForCandidateResponseViewModel>
    {
        public GetAllAttendancesForCandidateEndPoint(EndpointBaseParameters<GetAllAttendancesForCandidateRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllAttendancesForCandidate })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllAttendancesForCandidateResponseViewModel>>>> GetAllAttendancesForCandidate(
         [FromQuery] GetAllAttendancesForCandidateRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllAttendancesForCandidateQuery>());
            var response = result.Data.MapPage<GetAllAttendancesForCandidateDTO, GetAllAttendancesForCandidateResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllAttendancesForCandidateResponseViewModel>>
                    .Success(response, "Attendances filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllAttendancesForCandidateResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
