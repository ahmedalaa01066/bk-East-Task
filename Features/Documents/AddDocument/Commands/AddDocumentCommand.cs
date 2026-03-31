using EasyTask.Common.Requests;
using EasyTask.Features.Common.Documents.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Documents;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Documents.AddDocument.Commands
{
    public record AddDocumentCommand(string PhysicalName, string SourceId,
        DocumentType SourceType, string Path,string? ParentDocumentId) :IRequestBase<AddDocumentDTO>;
    public class AddDocumentCommandHandler : RequestHandlerBase<Document, AddDocumentCommand, AddDocumentDTO>
    {
        public AddDocumentCommandHandler(RequestHandlerBaseParameters<Document> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<AddDocumentDTO>> Handle(AddDocumentCommand request, CancellationToken cancellationToken)
        {
            var logicalName = Guid.NewGuid().ToString();

            // Ensure path is under wwwroot/Documents
            var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Documents", request.Path ?? string.Empty);
            var fullFolderPath = Path.Combine(rootPath, logicalName);

            if (!Directory.Exists(fullFolderPath))
                Directory.CreateDirectory(fullFolderPath);

            // Store a relative path for use in web URLs
            var relativePath = Path.Combine("Documents", request.Path ?? string.Empty, logicalName)
                .Replace("\\", "/");
            var document = new Document
            {
                LogicalName = logicalName,
                PhysicalName = request.PhysicalName,
                SourceId = request.SourceId,
                SourceType = request.SourceType,
                Path = relativePath,
                ParentDocumentId=request.ParentDocumentId
            };

            await _repository.AddAsync(document);
            _repository.SaveChanges();
            var documentDTO = document.MapOne<AddDocumentDTO>();
            return RequestResult<AddDocumentDTO>.Success(documentDTO);
        }

    }
}
