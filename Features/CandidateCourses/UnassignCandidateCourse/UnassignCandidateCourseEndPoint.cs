using EasyTask.Common.Endpoints;
using EasyTask.Features.CandidateCourses.UnassignCandidateCourse.Orchestrator;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidateCourses.UnassignCandidateCourse
{
    public class UnassignCandidateCourseEndPoint : EndpointBase<UnassignCandidateCourseRequestViewModel, UnassignCandidateCourseResponseViewModel>
    {
        public UnassignCandidateCourseEndPoint(EndpointBaseParameters<UnassignCandidateCourseRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.UnassignCandidateCourse })]
        public async Task<EndPointResponse<UnassignCandidateCourseResponseViewModel>> UnassignCandidateCourse([FromQuery] UnassignCandidateCourseRequestViewModel viewModel)
        {

            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<UnassignCandidateCourseOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<UnassignCandidateCourseResponseViewModel>.Success(new UnassignCandidateCourseResponseViewModel(), "Unassign Candidate From Course Successfully");
            else
                return EndPointResponse<UnassignCandidateCourseResponseViewModel>.Failure(result.ErrorCode);

        }

    }
}
