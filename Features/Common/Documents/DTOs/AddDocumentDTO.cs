using AutoMapper;
using EasyTask.Models.Documents;

namespace EasyTask.Features.Common.Documents.DTOs
{
    public record AddDocumentDTO(string ID,string Path);
    public class AddDocumentDTOProfile : Profile
    {
        public AddDocumentDTOProfile()
        {
            CreateMap<Document, AddDocumentDTO>();
        }
    }
}
