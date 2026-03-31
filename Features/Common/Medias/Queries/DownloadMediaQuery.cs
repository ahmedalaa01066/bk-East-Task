using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Medias.DTOs;
using EasyTask.Models.Medias;

namespace EasyTask.Features.Common.Medias.Queries
{
    public record DownloadMediaQuery(string ID):IRequestBase<DownloadMediaDTO>;
    public class DownloadMediaQueryHandler : RequestHandlerBase<Media, DownloadMediaQuery, DownloadMediaDTO>
    {
        public DownloadMediaQueryHandler(RequestHandlerBaseParameters<Media> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<DownloadMediaDTO>> Handle(
    DownloadMediaQuery request,
    CancellationToken cancellationToken)
        {
            var media = _repository.GetByID(request.ID);

            if (media == null)
                return RequestResult<DownloadMediaDTO>.Failure(ErrorCode.NotFound);

            // Root folder of uploads
            var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            // Combine with media.Path (normalize slashes)
            var relativePath = media.Path.Replace("/", Path.DirectorySeparatorChar.ToString())
                                         .Replace("\\", Path.DirectorySeparatorChar.ToString());

            var filePath = Path.Combine(rootPath, relativePath);

            if (!System.IO.File.Exists(filePath))
                return RequestResult<DownloadMediaDTO>.Failure(ErrorCode.NotFound);

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath, cancellationToken);
            var fileName = Path.GetFileName(filePath);
            var fileExtension = Path.GetExtension(filePath);
            var contentType = "application/octet-stream"; // default

            if (!string.IsNullOrEmpty(fileExtension))
            {
                var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(fileName, out contentType))
                    contentType = "application/octet-stream";
            }

            var dto = new DownloadMediaDTO(media.ID, fileName, fileBytes, contentType);

            return RequestResult<DownloadMediaDTO>.Success(dto);
        }


    }
}
