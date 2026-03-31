using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.GetCandidateAttendanceActivation
{
    public class GetCandidateAttendanceActivationEndpoint : EndpointBase<GetCandidateAttendanceActivationRequestViewModel, GetCandidateAttendanceActivationResponseViewModel>
    {
        public GetCandidateAttendanceActivationEndpoint(EndpointBaseParameters<GetCandidateAttendanceActivationRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetCandidateAttendanceActivation })]
        public async Task<EndPointResponse<GetCandidateAttendanceActivationResponseViewModel>> GetCandidateAttendanceActivation([FromQuery] GetCandidateAttendanceActivationRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetCandidateAttendanceActivationQuery>());

            GetCandidateAttendanceActivationResponseViewModel response = result.Data.MapOne<GetCandidateAttendanceActivationResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetCandidateAttendanceActivationResponseViewModel>.Success(response, "Get Candidate successfully.");
            else
                return EndPointResponse<GetCandidateAttendanceActivationResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
