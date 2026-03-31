using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.PermissionRequests;

namespace EasyTask.Features.Common.PermissionRequests.DTOs
{
    public class GetAllPermissionRequestsToManagerDTO
    {
        public DateOnly Date { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public RequestStatus PermissionRequestStatus { get; set; } = RequestStatus.Pending;
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string To { get; set; }
        public string PermissionId { get; set; }
        public string PermissionName { get; set; }
    }
    public class GetAllPermissionRequestsToManagerDTOProfile : Profile
    {
        public GetAllPermissionRequestsToManagerDTOProfile()
        {
            CreateMap<PermissionRequest, GetAllPermissionRequestsToManagerDTO>()
             .ForMember(dest => dest.CandidateName,
                        opt => opt.MapFrom(src => src.Candidate.FirstName + " " + src.Candidate.LastName))
             .ForMember(dest => dest.To,
                        opt => opt.MapFrom(src => src.Candidate.Management.Manager.FirstName + "" + src.Candidate.Management.Manager.LastName))
             .ForMember(dest => dest.PermissionName,
                        opt => opt.MapFrom(src => src.Permission.Name));

        }
    }
}
