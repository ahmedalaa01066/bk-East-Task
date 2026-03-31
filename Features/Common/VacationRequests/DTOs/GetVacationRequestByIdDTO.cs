using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.VacationRequests;

namespace EasyTask.Features.Common.VacationRequests.DTOs
{
    public class GetVacationRequestByIdDTO
    {
        public string ID { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public string VacationId { get; set; }
        public string VacationName { get; set; }
        public RequestStatus VacationRequestType { get; set; }
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
    }
    public class GetVacationRequestByIdDTOProfile : Profile
    {
        public GetVacationRequestByIdDTOProfile()
        {
            CreateMap<VacationRequest, GetVacationRequestByIdDTO>()
                                .ForMember(dest => dest.VacationName, opt => opt.MapFrom(src => src.Vacation.Name))
                                .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => src.Candidate.FirstName+" "+ src.Candidate.LastName))
                                   .ForMember(dest => dest.VacationRequestType,
                    opt => opt.MapFrom(src => src.VacationRequestStatus))
             ;
        }
    }
}
