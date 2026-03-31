using AutoMapper;
using EasyTask.Models.CandidatePermissions;

namespace EasyTask.Features.Common.CandidatePermissions.DTOs
{
    public class GetAllCandidatePermissionsDTO
    {
        public string ID {  get; set; } 
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string PermissionId { get; set; }
        public string PermissionName { get; set; }
        public TimeSpan NumOfHoursOfPermission { get; set; }
        public DateTime PermissionMonth { get; set; }
        public TimeSpan HoursLeftInMonth { get; set; }
    }

    public class GetAllCandidatePermissionsProfile : Profile
    {
        public GetAllCandidatePermissionsProfile()
        {
            CreateMap<CandidatePermission, GetAllCandidatePermissionsDTO>()
                   .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => string.Concat(src.Candidate.FirstName, " ", src.Candidate.LastName)))
                   .ForMember(dest => dest.PermissionName, opt => opt.MapFrom(src => src.Permission.Name));
        }
    }
}
