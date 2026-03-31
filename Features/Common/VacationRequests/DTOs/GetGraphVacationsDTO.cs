using AutoMapper;
using EasyTask.Models.VacationRequests;

namespace EasyTask.Features.Common.VacationRequests.DTOs
{
    public class GetGraphVacationsDTO
    {
        public string VacationId { get; set; }
        public string VacationName { get; set; }
        public DateOnly Date { get; set; }
        public int NumOfCandidateTakeVacation { get; set; }
    }

    public class GetGraphVacationsDTOProfile : Profile
    {
        public GetGraphVacationsDTOProfile()
        {
            CreateMap<VacationRequest, GetGraphVacationsDTO>()
                   .ForMember(dest => dest.VacationName, opt => opt.MapFrom(src => src.Vacation.Name));
        }
    }
}
