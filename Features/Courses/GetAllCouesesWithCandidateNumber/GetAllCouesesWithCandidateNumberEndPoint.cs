using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Courses.DTOs;
using EasyTask.Features.Common.Courses.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Courses.GetAllCouesesWithCandidateNumber
{
    public class GetAllCouesesWithCandidateNumberEndPoint : EndpointBase<GetAllCouesesWithCandidateNumberRequestViewModel, GetAllCouesesWithCandidateNumberResponseViewModel>
    {
        public GetAllCouesesWithCandidateNumberEndPoint(EndpointBaseParameters<GetAllCouesesWithCandidateNumberRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllCoursesWithCandidateNumber })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllCouesesWithCandidateNumberResponseViewModel>>>> GetAllCoursesWithCandidateNumber(
        [FromQuery] GetAllCouesesWithCandidateNumberRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllCouesesWithCandidateNumberQuery>());
            var response = result.Data.MapPage<GetAllCouesesWithCandidateNumberDTO, GetAllCouesesWithCandidateNumberResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllCouesesWithCandidateNumberResponseViewModel>>
                    .Success(response, "Courses filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllCouesesWithCandidateNumberResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
