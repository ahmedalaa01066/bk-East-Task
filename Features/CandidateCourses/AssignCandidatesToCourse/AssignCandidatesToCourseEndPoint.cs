using EasyTask.Common.Endpoints;
using EasyTask.Features.CandidateCourses.AssignCandidatesToCourse.Orchestrators;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidateCourses.AssignCandidatesToCourse
{
    public class AssignCandidatesToCourseEndPoint : EndpointBase<AssignCandidatesToCourseRequestViewModel, AssignCandidatesToCourseResponseViewModel>
    {
        public AssignCandidatesToCourseEndPoint(EndpointBaseParameters<AssignCandidatesToCourseRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AssignCandidatesToCourse })]
        public async Task<EndPointResponse<AssignCandidatesToCourseResponseViewModel>> AssignCandidatesToCourse(AssignCandidatesToCourseRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AssignCandidatesToCourseOrchestrator>());
            var response = result.Data.MapOne<AssignCandidatesToCourseResponseViewModel>();
            if (result.IsSuccess)
                return EndPointResponse<AssignCandidatesToCourseResponseViewModel>.Success(response, "Candidates Assigned to Course Successfully");
            else
                return EndPointResponse<AssignCandidatesToCourseResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
