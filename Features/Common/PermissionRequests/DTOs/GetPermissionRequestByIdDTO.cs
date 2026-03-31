using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.PermissionRequests;

namespace EasyTask.Features.Common.PermissionRequests.DTOs
{
    public class GetPermissionRequestByIdDTO
    {
        public string ID { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public string PermissionId { get; set; }
        public string PermissionName { get; set; }
        public RequestStatus PermissionRequestStatus { get; set; }
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
    }
    public class GetPermissionRequestByIdDTOProfile : Profile
    {
        public GetPermissionRequestByIdDTOProfile()
        {
            CreateMap<PermissionRequest, GetPermissionRequestByIdDTO>()
                .ForMember(dest => dest.PermissionRequestStatus,
                    opt => opt.MapFrom(src => src.PermissionRequestStatus))
                       .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => src.Candidate.FirstName + " " + src.Candidate.LastName))
                       .ForMember(dest => dest.PermissionName, opt => opt.MapFrom(src => src.Permission.Name));
        }
    }
}
