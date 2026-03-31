using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.Users;

namespace EasyTask.Features.Common.Users.DTOs
{
    public record VerifiedStatusDTO(string ID, string Name, string Mobile, Role RoleId, VerifyStatus VerifyStatus);
    public class VerifiedStatusProfile : Profile
    {
        public VerifiedStatusProfile()
        {
            CreateMap<User, VerifiedStatusDTO>()
                .ConstructUsing(src => new VerifiedStatusDTO(
                    src.ID,
                    src.Name,
                    src.Mobile,
                    src.RoleId,
                    src.VerifyStatus
                //src.Client != null ? src.Client.NationalNumber : string.Empty // Replace ?. with explicit null check
                ));
        }
    }

}
