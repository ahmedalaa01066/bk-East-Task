using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Attendances.DTOs;
using EasyTask.Features.Common.Attendances.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Attendances.GetAllShiftsDetailsForCandidate
{
    public class GetAllShiftsDetailsForCandidateEndPoint : EndpointBase<GetAllShiftsDetailsForCandidateRequestViewModel, GetAllShiftsDetailsForCandidateResponseViewModel>
    {
        public GetAllShiftsDetailsForCandidateEndPoint(EndpointBaseParameters<GetAllShiftsDetailsForCandidateRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllShiftsDetailsForCandidate })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllShiftsDetailsForCandidateResponseViewModel>>>> GetAllShiftsDetailsForCandidate(
         [FromQuery] GetAllShiftsDetailsForCandidateRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllShiftsDetailsForCandidateQuery>());
            var response = result.Data.MapPage<GetAllShiftsDetailsForCandidateDTO, GetAllShiftsDetailsForCandidateResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllShiftsDetailsForCandidateResponseViewModel>>
                    .Success(response, "Attendances filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllShiftsDetailsForCandidateResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
