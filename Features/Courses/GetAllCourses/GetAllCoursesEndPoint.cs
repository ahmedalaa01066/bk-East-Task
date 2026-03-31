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

namespace EasyTask.Features.Courses.GetAllCourses
{
    public class GetAllCoursesEndPoint : EndpointBase<GetAllCoursesRequestViewModel, GetAllCoursesResponseViewModel>
    {
        public GetAllCoursesEndPoint(EndpointBaseParameters<GetAllCoursesRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllCourses })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllCoursesResponseViewModel>>>> GetAllCourses(
         [FromQuery] GetAllCoursesRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllCoursesQuery>());
            var response = result.Data.MapPage<GetAllCoursesDTO, GetAllCoursesResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllCoursesResponseViewModel>>
                    .Success(response, "Courses filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllCoursesResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
