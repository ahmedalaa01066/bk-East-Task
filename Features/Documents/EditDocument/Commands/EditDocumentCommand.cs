using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Documents;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Documents.EditDocument.Commands
{
    public record EditDocumentCommand(string PhysicalName, string SourceId,
        DocumentType SourceType):IRequestBase<bool>;
    public class EditDocumentCommandHandler : RequestHandlerBase<Document, EditDocumentCommand, bool>
    {
        public EditDocumentCommandHandler(RequestHandlerBaseParameters<Document> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = _repository.Get(d =>
                     d.SourceId == request.SourceId &&
                     d.SourceType == request.SourceType).FirstOrDefault();

            if (document == null)
            {
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            }
            document.PhysicalName = request.PhysicalName;

            _repository.SaveIncluded(document,nameof(document.PhysicalName));
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
