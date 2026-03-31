using AutoMapper;
using EasyTask.Features.Common.Users.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Users.GetAllVerifiedStatus
{
    public record GetAllVerifiedStatusResponseViewModel(string ID,string Name, string Mobile, Role RoleId, VerifyStatus VerifyStatus, string NationalNumber);
    public class GetAllVerifiedStatusResponseProfile:Profile
    {
        public GetAllVerifiedStatusResponseProfile()
        {
            CreateMap<VerifiedStatusDTO, GetAllVerifiedStatusResponseViewModel>();
        }
    }

}
