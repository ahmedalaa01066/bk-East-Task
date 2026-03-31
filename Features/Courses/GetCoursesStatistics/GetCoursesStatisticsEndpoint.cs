using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Courses.Queries;
using EasyTask.Features.Courses.GetCourseById;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Courses.GetCoursesStatistics
{
    public class GetCoursesStatisticsEndpoint : EndpointBase<GetCoursesStatisticsRequestViewModel, GetCoursesStatisticsResponseViewModel>
    {
        public GetCoursesStatisticsEndpoint(EndpointBaseParameters<GetCoursesStatisticsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetCourseStatistics })]
        public async Task<EndPointResponse<GetCoursesStatisticsResponseViewModel>> GetCourseStatistics([FromQuery] GetCoursesStatisticsRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetCoursesStatisticsQuery>());

            GetCoursesStatisticsResponseViewModel response = result.Data.MapOne<GetCoursesStatisticsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetCoursesStatisticsResponseViewModel>.Success(response, "Get Course Statistics successfully.");
            else
                return EndPointResponse<GetCoursesStatisticsResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
