using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Courses.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Courses.GetCourseById
{
    public class GetCourseByIdEndPoint : EndpointBase<GetCourseByIdRequestViewModel, GetCourseByIdResponseViewModel>
    {
        public GetCourseByIdEndPoint(EndpointBaseParameters<GetCourseByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetCourseById })]
        public async Task<EndPointResponse<GetCourseByIdResponseViewModel>> GetCourseById([FromQuery] GetCourseByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetCourseByIdQuery>());

            GetCourseByIdResponseViewModel response = result.Data.MapOne<GetCourseByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetCourseByIdResponseViewModel>.Success(response, "Get Course successfully.");
            else
                return EndPointResponse<GetCourseByIdResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
