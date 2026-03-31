using EasyTask.Common.Requests;
using EasyTask.Models.Documents;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Documents.AddDocument.Commands
{
    public record AddFolderCommand(string Name, string ParentDocumentId) : IRequestBase<bool>;
    public class AddFolderCommandHandler : RequestHandlerBase<Document, AddFolderCommand, bool>
    {
        public AddFolderCommandHandler(RequestHandlerBaseParameters<Document> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AddFolderCommand request, CancellationToken cancellationToken)
        {
            var logicalName = Guid.NewGuid().ToString();
            var ParentDocument = await _repository.Get(d => d.ID == request.ParentDocumentId).FirstOrDefaultAsync();
            // Ensure path is under wwwroot/Documents
            var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", ParentDocument.Path ?? string.Empty);
            var fullFolderPath = Path.Combine(rootPath, logicalName);

            if (!Directory.Exists(fullFolderPath))
                Directory.CreateDirectory(fullFolderPath);
            // Store a relative path for use in web URLs
            var relativePath = Path.Combine(ParentDocument.Path ?? string.Empty, logicalName)
                .Replace("\\", "/");
            var document = new Document
            {
                LogicalName = logicalName,
                PhysicalName = request.Name,
                SourceId = ParentDocument.SourceId,
                SourceType = ParentDocument.SourceType,
                Path = relativePath,
                ParentDocumentId = request.ParentDocumentId
            };

            await _repository.AddAsync(document);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
