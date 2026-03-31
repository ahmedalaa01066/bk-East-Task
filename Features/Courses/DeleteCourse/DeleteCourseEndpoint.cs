using EasyTask.Common.Endpoints;
using EasyTask.Features.Courses.DeleteCourse.Commands;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Courses.DeleteCourse
{
    public class DeleteCourseEndpoint : EndpointBase<DeleteCourseRequestViewModel, DeleteCourseResponseViewModel>
    {
        public DeleteCourseEndpoint(EndpointBaseParameters<DeleteCourseRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteCourse })]
        public async Task<EndPointResponse<DeleteCourseResponseViewModel>> DeleteCourse(DeleteCourseRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteCourseCommand>());
            if (result.IsSuccess)
            {
                return EndPointResponse<DeleteCourseResponseViewModel>.Success(new DeleteCourseResponseViewModel(), "Course Deleted successfully.");
            }
            return EndPointResponse<DeleteCourseResponseViewModel>.Failure(result.ErrorCode,result.Message);

        }
    }
}
