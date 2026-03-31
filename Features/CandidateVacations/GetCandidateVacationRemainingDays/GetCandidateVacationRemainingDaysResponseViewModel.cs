using AutoMapper;
using EasyTask.Features.Common.CandidateVacations.DTOs;

namespace EasyTask.Features.CandidateVacations.GetCandidateVacationRemainingDays
{
    public record GetCandidateVacationRemainingDaysResponseViewModel(int MaxRequestNum, int RemainingDays);
    public class GetCandidateVacationRemainingDaysResponseProfile : Profile
    {
        public GetCandidateVacationRemainingDaysResponseProfile()
        {
            CreateMap<GetCandidateVacationRemainingDaysDTO, GetCandidateVacationRemainingDaysResponseViewModel>();
        }
    }
}
