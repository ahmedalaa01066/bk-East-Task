using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.CandidateCourses.DTOs;
using EasyTask.Features.Common.CandidateCourses.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidateCourses.GetAllCandidatesForCourse
{
    public class GetAllCandidatesForCourseEndPoint : EndpointBase<GetAllCandidatesForCourseRequestViewModel, GetAllCandidatesForCourseResponseViewModel>
    {
        public GetAllCandidatesForCourseEndPoint(EndpointBaseParameters<GetAllCandidatesForCourseRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllCandidatesForCourse })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllCandidatesForCourseResponseViewModel>>>> GetAllCandidatesForCourse(
         [FromQuery] GetAllCandidatesForCourseRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllCandidatesForCourseQuery>());
            var response = result.Data.MapPage<GetAllCandidatesForCourseDTO, GetAllCandidatesForCourseResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllCandidatesForCourseResponseViewModel>>
                    .Success(response, "Candidates filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllCandidatesForCourseResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
