using EasyTask.Common.Endpoints;
using EasyTask.Features.Candidates.EditCandidateAttendanceActivation.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.EditCandidateAttendanceActivation
{
    public class EditCandidateAttendanceActivationEndpoint : EndpointBase<EditCandidateAttendanceActivationRequestViewModel, EditCandidateAttendanceActivationResponseViewModel>
    {
        public EditCandidateAttendanceActivationEndpoint(EndpointBaseParameters<EditCandidateAttendanceActivationRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditCandidateAttendanceActivation })]
        public async Task<EndPointResponse<EditCandidateAttendanceActivationResponseViewModel>> EditCandidateAttendanceActivation(EditCandidateAttendanceActivationRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<EditCandidateAttendanceActivationCommand>());

            if (result.IsSuccess)
                return EndPointResponse<EditCandidateAttendanceActivationResponseViewModel>.Success(new EditCandidateAttendanceActivationResponseViewModel(), "Candidate Attendance Activation Updated successfully");
            else
                return EndPointResponse<EditCandidateAttendanceActivationResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
