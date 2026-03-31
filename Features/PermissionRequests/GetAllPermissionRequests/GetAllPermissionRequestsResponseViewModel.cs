using AutoMapper;
using EasyTask.Features.Common.PermissionRequests.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.PermissionRequests.GetAllPermissionRequests
{
    public record GetAllPermissionRequestsResponseViewModel(string ID,DateOnly Date, TimeSpan FromTime, TimeSpan ToTime, RequestStatus PermissionRequestStatus, 
        string CandidateId, string CandidateName, string To, string PermissionId, string PermissionName);
    public class GetAllPermissionRequestsResponseProfile : Profile
    {
        public GetAllPermissionRequestsResponseProfile()
        {
            CreateMap<GetAllPermissionRequestsDTO, GetAllPermissionRequestsResponseViewModel>();
        }
    }
}
