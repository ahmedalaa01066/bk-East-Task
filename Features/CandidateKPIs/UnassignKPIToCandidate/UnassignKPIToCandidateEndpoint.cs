using EasyTask.Common.Endpoints;
using EasyTask.Features.CandidateKPIs.UnassignKPIToCandidate.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidateKPIs.UnassignKPIToCandidate
{
    public class UnassignKPIToCandidateEndpoint : EndpointBase<UnassignKPIToCandidateRequestViewModel, UnassignKPIToCandidateResponseViewModel>
    {
        public UnassignKPIToCandidateEndpoint(EndpointBaseParameters<UnassignKPIToCandidateRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.UnassignKPIToCandidate })]
        public async Task<EndPointResponse<UnassignKPIToCandidateResponseViewModel>> UnassignKPIToCandidate(UnassignKPIToCandidateRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<UnassignKPIToCandidateCommand>());
            if (result.IsSuccess)
                return EndPointResponse<UnassignKPIToCandidateResponseViewModel>.Success(new UnassignKPIToCandidateResponseViewModel(), "KPI Unassigned to Candidate Successfully");
            else
                return EndPointResponse<UnassignKPIToCandidateResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
