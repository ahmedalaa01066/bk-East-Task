using EasyTask.Common.Endpoints;
using EasyTask.Features.Medias.AttachImageToCandidateDocument.Orchestrator;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Medias.AttachImageToCandidateDocument
{
    public class AttachImageToCandidateDocumentEndpoint : EndpointBase<AttachImageToCandidateDocumentRequestViewModel, AttachImageToCandidateDocumentResponseViewModel>
    {
        public AttachImageToCandidateDocumentEndpoint(EndpointBaseParameters<AttachImageToCandidateDocumentRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AttachImageToCandidateDocument })]
        public async Task<EndPointResponse<AttachImageToCandidateDocumentResponseViewModel>> AttachImageToCandidateDocument(AttachImageToCandidateDocumentRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AttachImageToCandidateDocumentOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<AttachImageToCandidateDocumentResponseViewModel>.Success(new AttachImageToCandidateDocumentResponseViewModel(), "Media Saved successfully");
            else
                return EndPointResponse<AttachImageToCandidateDocumentResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
