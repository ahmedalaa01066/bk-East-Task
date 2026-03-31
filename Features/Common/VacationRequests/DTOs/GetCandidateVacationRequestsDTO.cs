using AutoMapper;
using EasyTask.Models.VacationRequests;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.VacationRequests.DTOs
{
    public class GetCandidateVacationRequestsDTO
    {
        public string ID { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public RequestStatus VacationRequestType { get; set; }
        public string VacationId { get; set; }
        public string VacationName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class GetCandidateVacationRequestsProfile : Profile
    {
        public GetCandidateVacationRequestsProfile()
        {
            CreateMap<VacationRequest, GetCandidateVacationRequestsDTO>()
                .ForMember(dest => dest.VacationName, opt => opt.MapFrom(src => src.Vacation.Name));
        }
    }

}
