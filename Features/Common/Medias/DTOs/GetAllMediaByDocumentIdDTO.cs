using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.Medias;

namespace EasyTask.Features.Common.Medias.DTOs
{
    public record GetAllMediaByDocumentIdDTO(string ID,string Name,string Path,
        string SourceId,
       DocumentType SourceType);
    public class GetAllMediaByDocumentIdDTOProfile : Profile
    {
        public GetAllMediaByDocumentIdDTOProfile()
        {
            CreateMap<Media, GetAllMediaByDocumentIdDTO>()
       .ForCtorParam("ID", opt => opt.MapFrom(src => src.ID))
       .ForCtorParam("Name", opt => opt.MapFrom(src => Path.GetFileName(src.Path)))
       .ForCtorParam("Path", opt => opt.MapFrom(src => src.Path))
       .ForCtorParam("SourceId", opt => opt.MapFrom(src => src.SourceId))
       .ForCtorParam("SourceType", opt => opt.MapFrom(src => src.SourceType));

        }
    }
}
