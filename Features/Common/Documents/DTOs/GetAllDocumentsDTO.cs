using AutoMapper;
using EasyTask.Models.Documents;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.Documents.DTOs
{
   public record GetAllDocumentsDTO(
        string ID,
        string Name,
        string Path,
        bool IsFolder,
        string SourceId,
       DocumentType SourceType,
        int Count = 0
    );


    public class GetAllDocumentsDTOProfile : Profile
    {
        public GetAllDocumentsDTOProfile()
        {
            CreateMap<Document, GetAllDocumentsDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PhysicalName))
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path))
                .ForMember(dest => dest.Count, opt => opt.Ignore());
        }
    }

}
