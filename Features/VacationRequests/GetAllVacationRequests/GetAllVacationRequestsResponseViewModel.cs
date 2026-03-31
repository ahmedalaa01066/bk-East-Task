using AutoMapper;
using EasyTask.Features.Common.VacationRequests.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.VacationRequests.GetAllVacationRequests
{
    public record GetAllVacationRequestsResponseViewModel(
    string ID,
    DateOnly FromDate,
    DateOnly ToDate,
    RequestStatus VacationRequestType,
    string CandidateId,
    string CandidateName,
    string VacationId,
    string VacationName, DateTime CreatedDate, string Manager);
    public class GetAllVacationRequestsResponseProfile : Profile
    {
        public GetAllVacationRequestsResponseProfile()
        {
            CreateMap<GetAllVacationRequestsDTO, GetAllVacationRequestsResponseViewModel>();
        }
    }
}
