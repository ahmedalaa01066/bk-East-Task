using AutoMapper;
using EasyTask.Features.Common.Penalities.DTOs;

namespace EasyTask.Features.Penalities.GetPenalitiesByCandidateId
{
    public record GetPenalitiesByCandidateIdResponseViewModel(string ID, string Description, DateTime CreatedDate);
    public class GetPenalitiesByCandidateIdResponseProfile : Profile
    {
        public GetPenalitiesByCandidateIdResponseProfile()
        {
            CreateMap<GetPenalitiesByCandidateIdDTO, GetPenalitiesByCandidateIdResponseViewModel>();
        }
    }
}
