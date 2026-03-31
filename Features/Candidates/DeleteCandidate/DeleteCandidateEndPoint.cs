using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Candidates.DeleteCandidate.Commands;
using EasyTask.Helpers;

namespace EasyTask.Features.Candidates.DeleteCandidate
{
    public class DeleteCandidateEndPoint : EndpointBase<DeleteCandidateRequestViewModel, DeleteCandidateResponseViewModel>
    {
        public DeleteCandidateEndPoint(EndpointBaseParameters<DeleteCandidateRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteCandidate })]
        public async Task<EndPointResponse<DeleteCandidateResponseViewModel>> DeleteCandidate(DeleteCandidateRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteCandidateCommand>());
            if (result.IsSuccess)
            {
                return EndPointResponse<DeleteCandidateResponseViewModel>.Success(new DeleteCandidateResponseViewModel(), "Candidate Deleted successfully.");
            }
            return EndPointResponse<DeleteCandidateResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
