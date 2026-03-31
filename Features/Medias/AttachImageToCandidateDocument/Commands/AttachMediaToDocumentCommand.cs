using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.Medias;

namespace EasyTask.Features.Medias.AttachImageToCandidateDocument.Commands
{
    public record AttachImageToCandidateDocumentCommand(string SourceId, string DocumentId,string ImagePath) :IRequestBase<bool>;
    public class AttachImageToCandidateDocumentCommandHandler : RequestHandlerBase<Media, AttachImageToCandidateDocumentCommand, bool>
    {
        public AttachImageToCandidateDocumentCommandHandler(RequestHandlerBaseParameters<Media> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AttachImageToCandidateDocumentCommand request, CancellationToken cancellationToken)
        {
            var media = new Media
            {
                DocumentId = request.DocumentId,
                SourceId = request.SourceId,
                SourceType = SourceType.CandidateImage,
                Path = request.ImagePath
            };
            
            _repository.Add(media);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
