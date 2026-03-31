using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Documents.DTOs;
using EasyTask.Features.Common.Medias.Queries;
using EasyTask.Helpers;
using EasyTask.Models.Documents;
using EasyTask.Models.Enums;
using EasyTask.Models.Managements;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;


namespace EasyTask.Features.Common.Documents.Queries
{
    public record GetAllDocumentsQuery(DocumentType? SourceType,string? ParentDocumentId, int pageIndex = 1,
        int pageSize = 100) :IRequestBase<PagingViewModel<GetAllDocumentsDTO>>;
    public class GetAllDocumentsQueryHandler : RequestHandlerBase<Document, GetAllDocumentsQuery, PagingViewModel<GetAllDocumentsDTO>>
    {
        public GetAllDocumentsQueryHandler(RequestHandlerBaseParameters<Document> requestParameters) : base(requestParameters)
        {
        }
        public override async Task<RequestResult<PagingViewModel<GetAllDocumentsDTO>>> Handle(GetAllDocumentsQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Document>(true);

            predicate = predicate.And(d => !request.SourceType.HasValue || d.SourceType == request.SourceType.Value)
                .And(d => request.ParentDocumentId.IsNullOrEmpty() || d.ParentDocumentId == request.ParentDocumentId);

            var docsQuery = _repository.Get(predicate)
                .Include(d => d.Medias)
                .Include(d => d.ChildDocuments)
                .Select(doc => new GetAllDocumentsDTO(
                    doc.ID,
                    doc.PhysicalName,
                    doc.Path,
                    true,
                    doc.SourceId,
                    doc.SourceType,
                    doc.ChildDocuments.Count + doc.Medias.Count
                ));

            var docs = await docsQuery.ToListAsync(cancellationToken);

            var combined = docs.AsEnumerable();

            if (!request.ParentDocumentId.IsNullOrEmpty())
            {
                var files = await _mediator.Send(new GetAllMediaByDocumentIdQuery(request.ParentDocumentId));

                var media = files.Data.Select(m => new GetAllDocumentsDTO(
                    m.ID,
                    m.Name,
                    m.Path,
                    false,
                    m.SourceId,
                    m.SourceType,
                    0
                ));

                combined = combined.Concat(media); 
            }

            var pagedResult = combined.AsQueryable().ToPages(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllDocumentsDTO>>.Success(pagedResult);
        }

    }
}
