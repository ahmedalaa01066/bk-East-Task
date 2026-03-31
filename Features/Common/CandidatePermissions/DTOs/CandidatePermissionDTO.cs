using AutoMapper;
using EasyTask.Models.CandidatePermissions;

namespace EasyTask.Features.Common.CandidatePermissions.DTOs
{
    public class CandidatePermissionDTO
    {
        public string ID { get; set; }
        public string CandidateId { get; set; }
        public string PermissionId { get; set; }
        public TimeSpan NumOfHoursOfPermission { get; set; }
        public DateTime PermissionMonth { get; set; }
        public TimeSpan HoursLeftInMonth { get; set; }
    }
    public class CandidatePermissionDTOProfile : Profile
    {
        public CandidatePermissionDTOProfile()
        {
            CreateMap<CandidatePermission, CandidatePermissionDTO>();
        }
    }
}
