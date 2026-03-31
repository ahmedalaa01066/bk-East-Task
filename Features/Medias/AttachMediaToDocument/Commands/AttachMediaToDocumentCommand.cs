using EasyTask.Common.Requests;
using EasyTask.Features.Common.Medias.DTOs;
using EasyTask.Models.Medias;

namespace EasyTask.Features.Medias.AttachMediaToDocument.Commands
{
    public record AttachMediaToDocumentCommand(string SourceId, string DocumentId,
        List<AttachMediaToDocumentDTO> AttachMediaToDocumentDTOs) :IRequestBase<bool>;
    public class AttachMediaToDocumentCommandHandler : RequestHandlerBase<Media, AttachMediaToDocumentCommand, bool>
    {
        public AttachMediaToDocumentCommandHandler(RequestHandlerBaseParameters<Media> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AttachMediaToDocumentCommand request, CancellationToken cancellationToken)
        {
            //var documentExists =  _repository.Any(d => d.ID == request.DocumentId);

            //if (!documentExists)
            //    return RequestResult<bool>.Failure(ErrorCode.NotFound);

            var mediaList = new List<Media>();

            foreach (var dto in request.AttachMediaToDocumentDTOs)
            {
                var media = new Media
                {
                    DocumentId = request.DocumentId,
                    SourceId = request.SourceId,
                    SourceType = dto.SourceType,
                    Path = dto.Path
                };

                mediaList.Add(media);
            }

             _repository.AddRange(mediaList);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
