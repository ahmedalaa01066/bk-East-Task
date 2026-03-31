using AutoMapper;
using EasyTask.Features.Common.CandidateVacations.DTOs;

namespace EasyTask.Features.CandidateVacations.GetAllCandidateVacations
{
    public record GetAllCandidateVacationsResponseViewModel(string ID, string CandidateId, string CandidateName, string VacationId
        , string VacationName, int MaxRequestNum, int Counter,int Year);
    public class GetAllCandidateVacationsResponseProfile : Profile
    {
        public GetAllCandidateVacationsResponseProfile()
        {
            CreateMap<GetAllCandidateVacationsDTO, GetAllCandidateVacationsResponseViewModel>();
        }
    }
}
