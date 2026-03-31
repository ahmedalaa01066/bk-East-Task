using EasyTask.Common.Requests;
using EasyTask.Features.Medias.AttachImageToCandidateDocument.Commands;
using EasyTask.Features.Medias.DeleteMedia.Commands;
using EasyTask.Models.Enums;
using EasyTask.Models.Medias;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Medias.AttachImageToCandidateDocument.Orchestrator
{
    public record AttachImageToCandidateDocumentOrchestrator(string SourceId, string DocumentId, string ImagePath) : IRequestBase<bool>;
    public class AttachImageToCandidateDocumentOrchestratorHandler : RequestHandlerBase<Media, AttachImageToCandidateDocumentOrchestrator, bool>
    {
        public AttachImageToCandidateDocumentOrchestratorHandler(RequestHandlerBaseParameters<Media> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AttachImageToCandidateDocumentOrchestrator request, CancellationToken cancellationToken)
        {
            var ImageID = await _repository.Get(m => m.SourceId == request.SourceId && m.SourceType == SourceType.CandidateImage)
                .Select(m => m.ID)
                .FirstOrDefaultAsync();
            if (ImageID != null)
            { 
                var checkDelete = await _mediator.Send(new DeleteMediaCommand(ImageID));
                
            }
            var checkAdd = await _mediator.Send(new AttachImageToCandidateDocumentCommand(request.SourceId, request.DocumentId, request.ImagePath));
            if (!checkAdd.IsSuccess)
            {
                return RequestResult<bool>.Failure(checkAdd.ErrorCode);
            }
            return RequestResult<bool>.Success(true);
        }
    }
}
