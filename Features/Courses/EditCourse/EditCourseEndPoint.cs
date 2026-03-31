using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Courses.EditCourse.Orchestrators;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Courses.EditCourse
{
    public class EditCourseEndPoint : EndpointBase<EditCourseRequestViewModel, EditCourseResponseViewModel>
    {
        public EditCourseEndPoint(EndpointBaseParameters<EditCourseRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditCourse })]
        public async Task<EndPointResponse<EditCourseResponseViewModel>> EditCourse(EditCourseRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditCourseOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<EditCourseResponseViewModel>.Success(new EditCourseResponseViewModel(), "Course Updated Successfully");
            else
                return EndPointResponse<EditCourseResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
