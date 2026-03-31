using EasyTask.Common.Endpoints;
using EasyTask.Features.CandidateCourses.UnassignManagmentFromCourse.Command;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidateCourses.UnassignManagmentFromCourse
{
    public class UnassignManagmentFromCourseEndPoint : EndpointBase<UnassignManagmentFromCourseRequestViewModel, UnassignManagmentFromCourseResponseViewModel>
    {
        public UnassignManagmentFromCourseEndPoint(EndpointBaseParameters<UnassignManagmentFromCourseRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.UnassignManagmentFromCourse })]
        public async Task<EndPointResponse<UnassignManagmentFromCourseResponseViewModel>> UnassignManagmentFromCourse([FromQuery] UnassignManagmentFromCourseRequestViewModel viewModel)
        {

            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<UnassignManagmentFromCourseCommand>());
            if (result.IsSuccess)
                return EndPointResponse<UnassignManagmentFromCourseResponseViewModel>.Success(new UnassignManagmentFromCourseResponseViewModel(), "Unassign Managment From Course Successfully");
            else
                return EndPointResponse<UnassignManagmentFromCourseResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
