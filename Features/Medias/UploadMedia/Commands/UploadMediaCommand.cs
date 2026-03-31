using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.Medias;
using MediatR.Wrappers;

namespace EasyTask.Features.Medias.UploadMedia.Commands;

public record UploadMediaCommand(List<IFormFile> Files, string Path = "Media") : IRequestBase<List<string>>;


public class UploadMediaCommandHandler : RequestHandlerBase<Media, UploadMediaCommand, List<string>>
{
    public UploadMediaCommandHandler(RequestHandlerBaseParameters<Media> requestParameters) : base(requestParameters)
    {
    }

    public async override Task<RequestResult<List<string>>> Handle(UploadMediaCommand request, CancellationToken cancellationToken)
    {
        if (request.Files == null || !request.Files.Any())
        {
            return RequestResult<List<string>>.Failure(ErrorCode.NotFound);
        }

        string baseFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        // Remove leading slashes so Path.Combine works correctly
        string safePath = request.Path.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

        string fullPath = Path.Combine(baseFolder, safePath);

        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
        }

        var resultPaths = new List<string>();

        foreach (var file in request.Files)
        {
            if (file.Length == 0) continue;

            string name = DateTime.Now.Ticks + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(fullPath, name);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                string relativePath = Path.Combine(safePath, name).Replace("\\", "/");
                resultPaths.Add(relativePath);
            }
            catch
            {
                return RequestResult<List<string>>.Failure(ErrorCode.None);
            }
        }

        return RequestResult<List<string>>.Success(resultPaths);
    }

}