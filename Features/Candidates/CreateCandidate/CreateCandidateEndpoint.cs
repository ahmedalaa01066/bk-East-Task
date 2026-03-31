using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Candidates.CreateCandidate.Orchestrator;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Candidates.CreateCandidate
{
    public class CreateCandidateEndpoint : EndpointBase<CreateCandidateRequestViewModel, CreateCandidateResponseViewModel>
    {
        public CreateCandidateEndpoint(EndpointBaseParameters<CreateCandidateRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateCandidate })]
        public async Task<EndPointResponse<CreateCandidateResponseViewModel>> CreateCandidate(CreateCandidateRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateCandidateOrchestrator>());
            var response = result.Data.MapOne<CreateCandidateResponseViewModel>();
            if (result.IsSuccess)
                return EndPointResponse<CreateCandidateResponseViewModel>.Success(response, "Candidate Added Successfully");
            else
                return EndPointResponse<CreateCandidateResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
