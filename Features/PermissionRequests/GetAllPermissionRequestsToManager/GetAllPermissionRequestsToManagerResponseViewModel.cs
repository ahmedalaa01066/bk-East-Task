using AutoMapper;
using EasyTask.Features.Common.PermissionRequests.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.PermissionRequests.GetAllPermissionRequestsToManager
{
    public record GetAllPermissionRequestsToManagerResponseViewModel(DateOnly Date, TimeSpan FromTime, TimeSpan ToTime, RequestStatus PermissionRequestStatus,
        string CandidateId, string CandidateName, string To, string PermissionId, string PermissionName);
    public class GetAllPermissionRequestsToManagerResponseProfile : Profile
    {
        public GetAllPermissionRequestsToManagerResponseProfile()
        {
            CreateMap<GetAllPermissionRequestsToManagerDTO, GetAllPermissionRequestsToManagerResponseViewModel>();
        }
    }
}
