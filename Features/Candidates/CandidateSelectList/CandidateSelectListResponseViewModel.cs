using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;

namespace EasyTask.Features.Candidates.CandidateSelectList
{
    public record CandidateSelectListResponseViewModel(string ID, string Name);
    public class CandidateSelectListResponseProfile:Profile
    {
        public CandidateSelectListResponseProfile()
        {
            CreateMap<CandidateSelectListDTO, CandidateSelectListResponseViewModel>();
        }
    }
}
