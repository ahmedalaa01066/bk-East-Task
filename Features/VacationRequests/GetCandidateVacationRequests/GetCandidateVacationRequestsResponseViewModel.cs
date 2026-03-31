using AutoMapper;
using EasyTask.Features.Common.VacationRequests.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.VacationRequests.GetCandidateVacationRequests
{
    public record GetCandidateVacationRequestsResponseViewModel(
        string ID,
        DateOnly FromDate,
        DateOnly ToDate,
        RequestStatus VacationRequestStatus,
        string VacationId,
        string VacationName,
        DateTime CreatedDate
     );
    public class GetCandidateVacationRequestsResponseProfile : Profile
    {
        public GetCandidateVacationRequestsResponseProfile()
        {
            CreateMap<GetCandidateVacationRequestsDTO, GetCandidateVacationRequestsResponseViewModel>();
        }
    }
}
