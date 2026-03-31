
using AutoMapper;
using EasyTask.Models.Medias;

namespace EasyTask.Features.Common.Medias.DTOs
{
    public record DownloadMediaDTO(string ID, string FileName, byte[] FileContent, string ContentType);

    public class DownloadMediaDTOProfile : Profile
    {
        public DownloadMediaDTOProfile()
        {
            CreateMap<Media, DownloadMediaDTO>();
        }
    }
}
