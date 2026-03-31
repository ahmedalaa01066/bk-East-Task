using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Documents;

namespace EasyTask.Features.Documents.EditParentDocumentId.Commands
{
    public record EditParentDocumentIdCommand(string ID,string ParentDocumentId):IRequestBase<bool>;
    public class EditParentDocumentIdCommandHandler : RequestHandlerBase<Document, EditParentDocumentIdCommand, bool>
    {
        public EditParentDocumentIdCommandHandler(RequestHandlerBaseParameters<Document> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditParentDocumentIdCommand request, CancellationToken cancellationToken)
        {
            var document = _repository.Get(d =>d.ID==request.ID).FirstOrDefault();

            if (document == null)
            {
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            }
            document.ParentDocumentId = request.ParentDocumentId;

            _repository.SaveIncluded(document, nameof(document.ParentDocumentId));
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
