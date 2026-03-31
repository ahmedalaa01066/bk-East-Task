using EasyTask.Common.Endpoints;
using EasyTask.Features.Candidates.EditCandidate.Orchestrator;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.EditCandidate
{
    public class EditCandidateEndPoint : EndpointBase<EditCandidateRequestViewModel, EditCandidateResponseViewModel>
    {
        public EditCandidateEndPoint(EndpointBaseParameters<EditCandidateRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditCandidate })]
        public async Task<EndPointResponse<EditCandidateResponseViewModel>> EditCandidate(EditCandidateRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<EditCandidateOrchestrator>());

            if (result.IsSuccess)
                return EndPointResponse<EditCandidateResponseViewModel>.Success(new EditCandidateResponseViewModel(), "Candidate Updated successfully");
            else
                return EndPointResponse<EditCandidateResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
