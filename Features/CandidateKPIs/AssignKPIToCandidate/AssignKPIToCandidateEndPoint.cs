using EasyTask.Common.Endpoints;
using EasyTask.Features.CandidateKPIs.AssignKPIToCandidate.Orchestrators;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidateKPIs.AssignKPIToCandidate
{
    public class AssignKPIToCandidateEndPoint : EndpointBase<AssignKPIToCandidateRequestViewModel, AssignKPIToCandidateResponseViewModel>
    {
        public AssignKPIToCandidateEndPoint(EndpointBaseParameters<AssignKPIToCandidateRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AssignKPIToCandidate })]
        public async Task<EndPointResponse<AssignKPIToCandidateResponseViewModel>> AssignKPIToCandidate(AssignKPIToCandidateRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AssignKPIToCandidateOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<AssignKPIToCandidateResponseViewModel>.Success(new AssignKPIToCandidateResponseViewModel(), "KPI Assigned to Candidate Successfully");
            else
                return EndPointResponse<AssignKPIToCandidateResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
