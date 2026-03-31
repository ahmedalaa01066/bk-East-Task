using AutoMapper;
using EasyTask.Features.Common.Penalities.DTOs;

namespace EasyTask.Features.Penalities.GetAllPenalities
{
    public record GetAllPenalitiesResponseViewModel
    (
        string ID,
        string Description,
        string CandidateId,
        string CandidateName
        );
    public class GetAllPenalitiesResponseProfile : Profile
    {
        public GetAllPenalitiesResponseProfile()
        {
            CreateMap<GetAllPenalitiesDTO, GetAllPenalitiesResponseViewModel>();
        }
    }
}
