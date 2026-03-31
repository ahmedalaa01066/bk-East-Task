using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.Medias;

namespace EasyTask.Features.Common.Medias.DTOs
{
    public record AttachMediaToDocumentDTO(SourceType SourceType, string Path);
    public class AttachMediaToDocumentProfile : Profile
    {
        public AttachMediaToDocumentProfile()
        {
            CreateMap<Media, AttachMediaToDocumentDTO>();
        }
    }
}
