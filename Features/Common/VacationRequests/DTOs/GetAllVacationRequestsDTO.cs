using AutoMapper;
using EasyTask.Models.VacationRequests;
using EasyTask.Models.Vacations;
using EasyTask.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Features.Common.VacationRequests.DTOs
{
    public class GetAllVacationRequestsDTO
    {
        public string ID {  get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public RequestStatus VacationRequestType { get; set; }
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string VacationId { get; set; }
        public string VacationName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Manager { get; set; }
    }
    public class GetAllVacationRequestsProfile : Profile
    {
        public GetAllVacationRequestsProfile()
        {
            CreateMap<VacationRequest, GetAllVacationRequestsDTO>()
                .ForMember(dest => dest.CandidateName,
                    opt => opt.MapFrom(src => src.Candidate.FirstName + " " + src.Candidate.LastName))
                .ForMember(dest => dest.VacationRequestType,
                    opt => opt.MapFrom(src => src.VacationRequestStatus))
                .ForMember(dest => dest.VacationName,
                    opt => opt.MapFrom(src => src.Vacation.Name)).ForMember(dest => dest.Manager,
                    opt => opt.MapFrom(src => src.Candidate.Management.Manager.FirstName + " " + src.Candidate.Management.Manager.LastName));
        }
    }

}
