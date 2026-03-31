using AutoMapper;
using EasyTask.Features.Common.CandidatePermissions.DTOs;

namespace EasyTask.Features.CandidatePermissions.GetAllCandidatePermissions
{
    public class GetAllCandidatePermissionsResponseViewModel
    {
        public string ID { get; set; }
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string PermissionId { get; set; }
        public string PermissionName { get; set; }
        public TimeSpan NumOfHoursOfPermission { get; set; }
        public DateTime PermissionMonth { get; set; }
        public TimeSpan HoursLeftInMonth { get; set; }
    }
    public class GetAllCandidatePermissionsResponseProfile : Profile
    {
        public GetAllCandidatePermissionsResponseProfile()
        {
            CreateMap<GetAllCandidatePermissionsDTO, GetAllCandidatePermissionsResponseViewModel>();
        }
    }
}
