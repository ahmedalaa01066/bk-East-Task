using AutoMapper;
using EasyTask.Features.Common.PermissionRequests.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.PermissionRequests.GetPermissionRequestById
{
    public class GetPermissionRequestByIdResponseViewModel
    {
        public string ID { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public string PermissionId { get; set; }
        public string PermissionName {  get; set; }
        public RequestStatus PermissionRequestStatus { get; set; }
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
    }
    public class GetPermissionRequestByIdResponseProfile : Profile
    {
        public GetPermissionRequestByIdResponseProfile()
        {
            CreateMap<GetPermissionRequestByIdDTO, GetPermissionRequestByIdResponseViewModel>();
        }
    }
}
