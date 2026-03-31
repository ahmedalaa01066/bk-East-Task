using AutoMapper;
using EasyTask.Features.Common.Medias.DTOs;

namespace EasyTask.Features.Medias.DownloadMedia
{
    public record DownloadMediaResponseViewModel(string ID, string FileName, byte[] FileContent, string ContentType);
    public class DownloadMediaResponseProfile : Profile
    {
        public DownloadMediaResponseProfile()
        {
            CreateMap<DownloadMediaDTO, DownloadMediaResponseViewModel>();
        }
    }
}
