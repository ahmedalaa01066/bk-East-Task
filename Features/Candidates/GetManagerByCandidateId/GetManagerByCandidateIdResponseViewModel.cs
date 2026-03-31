using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;

namespace EasyTask.Features.Candidates.GetManagerByCandidateId
{
    public record GetManagerByCandidateIdResponseViewModel(string ID, string ManagerName, string Email, string Level);
    public class GetManagerByCandidateIdResponseProfile : Profile
    {
        public  GetManagerByCandidateIdResponseProfile()
        {
            CreateMap<GetManagerByCandidateIdDTO, GetManagerByCandidateIdResponseViewModel>();
        }
    }
}
