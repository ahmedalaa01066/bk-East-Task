using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Courses.DTOs;
using EasyTask.Features.Common.Courses.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Courses.GetAllCoursesByCandidateId
{
    public class GetAllCoursesByCandidateIdEndpoint : EndpointBase<GetAllCoursesByCandidateIdRequestViewModel, GetAllCoursesByCandidateIdResponseViewModel>
    {
        public GetAllCoursesByCandidateIdEndpoint(EndpointBaseParameters<GetAllCoursesByCandidateIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllCoursesByCandidateId })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllCoursesByCandidateIdResponseViewModel>>>> GetAllCoursesByCandidateId(
         [FromQuery] GetAllCoursesByCandidateIdRequestViewModel filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllCoursesByCandidateIdQuery>());
            var response = result.Data.MapPage<GetAllCoursesByCandidateIdDTO, GetAllCoursesByCandidateIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllCoursesByCandidateIdResponseViewModel>>
                    .Success(response, "Courses got successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllCoursesByCandidateIdResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
