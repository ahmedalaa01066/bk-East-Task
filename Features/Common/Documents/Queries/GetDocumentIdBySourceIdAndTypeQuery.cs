using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Documents.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Documents;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.Documents.Queries
{
    public record GetDocumentIdBySourceIdAndTypeQuery(string ID, DocumentType DocumentType) :IRequestBase<AddDocumentDTO>;
    public class GetDocumentIdBySourceIdAndTypeQueryQueryHandler : RequestHandlerBase<Document, GetDocumentIdBySourceIdAndTypeQuery, AddDocumentDTO>
    {
        public GetDocumentIdBySourceIdAndTypeQueryQueryHandler(RequestHandlerBaseParameters<Document> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<AddDocumentDTO>> Handle(GetDocumentIdBySourceIdAndTypeQuery request, CancellationToken cancellationToken)
        {
            var document =  _repository.Get(d =>
                           d.SourceId == request.ID &&
                           d.SourceType ==request.DocumentType).FirstOrDefault().MapOne<AddDocumentDTO>();

            if (document == null)
            {
                return RequestResult<AddDocumentDTO>.Failure(ErrorCode.NotFound);
            }

            return RequestResult<AddDocumentDTO>.Success(document);
        }
    }
}
