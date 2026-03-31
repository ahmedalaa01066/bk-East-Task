using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Courses.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Courses.SelectCourseList
{
    public class SelectCourseListEndPoint : EndpointBase<SelectCourseListRequestViewModel, SelectCourseListResponseViewModel>
    {
        public SelectCourseListEndPoint(EndpointBaseParameters<SelectCourseListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.SelectCourseList })]
        public async Task<EndPointResponse<IEnumerable<SelectCourseListResponseViewModel>>> SelectCourseList([FromQuery] SelectCourseListRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<SelectCourseListQuery>());

            var response = result.Data.MapList<SelectCourseListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<SelectCourseListResponseViewModel>>.Success(response, "Courses filtered successfully.");
            else
                return EndPointResponse<IEnumerable<SelectCourseListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
