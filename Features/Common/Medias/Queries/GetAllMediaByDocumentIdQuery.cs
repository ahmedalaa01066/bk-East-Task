using EasyTask.Common.Requests;
using EasyTask.Features.Common.Medias.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Medias;

namespace EasyTask.Features.Common.Medias.Queries
{
    public record GetAllMediaByDocumentIdQuery(string ParentDocumentId):IRequestBase<IEnumerable<GetAllMediaByDocumentIdDTO>>;
    public class GetAllMediaByDocumentIdQueryHandler : RequestHandlerBase<Media, GetAllMediaByDocumentIdQuery, IEnumerable<GetAllMediaByDocumentIdDTO>>
    {
        public GetAllMediaByDocumentIdQueryHandler(RequestHandlerBaseParameters<Media> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<GetAllMediaByDocumentIdDTO>>> Handle(GetAllMediaByDocumentIdQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Get(d => d.DocumentId == request.ParentDocumentId).MapList< GetAllMediaByDocumentIdDTO>();
            return RequestResult<IEnumerable<GetAllMediaByDocumentIdDTO>>.Success(query);   

        }
    }
}
