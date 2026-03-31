using AutoMapper;
using EasyTask.Features.Common.VacationRequests.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.VacationRequests.GetVacationRequestById
{
    public class GetVacationRequestByIdResponseViewModel
    {
        public string ID { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public string VacationId {  get; set; }
        public string VacationName { get; set; }
       public RequestStatus VacationRequestType{ get; set; }
       public string CandidateId { get; set; }
       public string CandidateName { get; set; }
    }
    public class GetVacationRequestByIdResponseProfile : Profile
    {
        public GetVacationRequestByIdResponseProfile()
        {
            CreateMap<GetVacationRequestByIdDTO, GetVacationRequestByIdResponseViewModel>();
        }
    }
}
