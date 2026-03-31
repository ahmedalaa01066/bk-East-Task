using AutoMapper;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.DTOs
{
    public record UserDataDTO(string ID, string Name, string Phone, string Email, string? Path);
    public class UserDataDTOProfile : Profile
    {
        public UserDataDTOProfile()
        {
            CreateMap<User, UserDataDTO>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Mobile))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)); 
        }
    }


}
