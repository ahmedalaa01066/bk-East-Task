using AutoMapper;
using EasyTask.Models.Medias;

namespace EasyTask.Features.Common.Medias.DTOs
{
    public record MediaDTO(string ID,string Path);
    public class MediaDTOProfile : Profile
    {
        public MediaDTOProfile() { 
            CreateMap<Media, MediaDTO>();
        }
    }

}
