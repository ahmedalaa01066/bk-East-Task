using AutoMapper;
using EasyTask.Models.CandidateVacations;

namespace EasyTask.Features.Common.CandidateVacations.DTOs
{
    public class GetAllCandidateVacationsDTO
    {
        public string ID {  get; set; } 
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string VacationId { get; set; }
        public string VacationName { get; set; }
        public int MaxRequestNum { get; set; }
        public int Counter { get; set; }
        public int Year { get; set; }
    }

    public class GetAllCandidateVacationsProfile : Profile
    {
        public GetAllCandidateVacationsProfile()
        {
            CreateMap<CandidateVacation, GetAllCandidateVacationsDTO>()
                   .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => string.Concat(src.Candidate.FirstName, " ", src.Candidate.LastName)))
                   .ForMember(dest => dest.VacationName, opt => opt.MapFrom(src => src.Vacation.Name))
                   .ForMember(dest => dest.MaxRequestNum, opt => opt.MapFrom(src => src.Vacation.MaxRequestNum));
        }
    }
}
