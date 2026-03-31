using AutoMapper;
using EasyTask.Features.Common.Documents.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Documents.GetAllDocuments
{
    public record GetAllDocumentsResponseViewModel(string ID,
    string Name,
    string Path,
    bool IsFolder,
    string SourceId,
    DocumentType SourceType,
    int Count = 0);
    public class GetAllDocumentsResponseProfile : Profile
    {
        public GetAllDocumentsResponseProfile()
        {
            CreateMap<GetAllDocumentsDTO, GetAllDocumentsResponseViewModel>();
        }
    }
}
