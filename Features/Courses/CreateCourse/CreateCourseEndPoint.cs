using EasyTask.Common.Endpoints;
using EasyTask.Features.Courses.CreateCourse.Orchestrators;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Courses.CreateCourse
{
    public class CreateCourseEndPoint : EndpointBase<CreateCourseRequestViewModel, CreateCourseResponseViewModel>
    {
        public CreateCourseEndPoint(EndpointBaseParameters<CreateCourseRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateCourse })]
        public async Task<EndPointResponse<CreateCourseResponseViewModel>> CreateCourse(CreateCourseRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateCourseOrchestrator>());
            var response = result.Data.MapOne<CreateCourseResponseViewModel>();
            if (result.IsSuccess)
                return EndPointResponse<CreateCourseResponseViewModel>.Success(response, "Course Added Successfully");
            else
                return EndPointResponse<CreateCourseResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
