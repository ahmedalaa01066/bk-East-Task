using AutoMapper;
using EasyTask.Features.Common.Medias.DTOs;

namespace EasyTask.Features.Medias.GetAllMediaByDocumentId
{
    public record GetAllMediaByDocumentIdResponseViewModel(string ID, string Name, string Path);
    public class GetAllMediaByDocumentIdResponseProfile : Profile
    {
        public GetAllMediaByDocumentIdResponseProfile()
        {
            CreateMap<GetAllMediaByDocumentIdDTO, GetAllMediaByDocumentIdResponseViewModel>();
        }
    }
}
