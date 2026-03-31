using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Medias.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.Medias;

namespace EasyTask.Features.Common.Medias.Queries
{
    public record GetAllMediaForAnySourceQuery(string SourceId, SourceType SourceType) : IRequestBase<IEnumerable<MediaDTO>>;
    public class GetAllMediaForAnySourceQueryHandler : RequestHandlerBase<Media, GetAllMediaForAnySourceQuery, IEnumerable<MediaDTO>>
    {
        public GetAllMediaForAnySourceQueryHandler(RequestHandlerBaseParameters<Media> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<MediaDTO>>> Handle(GetAllMediaForAnySourceQuery request, CancellationToken cancellationToken)
        {
            var mediaEntities = _repository.Get(c => c.SourceId == request.SourceId && c.SourceType == request.SourceType).ToList();
            if (mediaEntities is null)
            {
                return RequestResult<IEnumerable<MediaDTO>>.Failure(ErrorCode.MediaNotFound);
            }
            var mediaDTO = mediaEntities.MapList<MediaDTO>();

            return RequestResult<IEnumerable<MediaDTO>>.Success(mediaDTO);
        }
    }
}
