using AutoMapper;
using EasyTask.Models.CandidateVacations;

namespace EasyTask.Features.Common.CandidateVacations.DTOs
{
    public record GetCandidateVacationRemainingDaysDTO(int MaxRequestNum,int RemainingDays);
    public class GetCandidateVacationRemainingDaysDTOProfile : Profile
    {
        public GetCandidateVacationRemainingDaysDTOProfile()
        {
            CreateMap<CandidateVacation, GetCandidateVacationRemainingDaysDTO>();
        }
    }
}
