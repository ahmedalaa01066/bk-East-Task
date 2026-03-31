using AutoMapper;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Candidates.DTOs;

namespace EasyTask.Features.Candidates.ManagerSelectList
{
    public record ManagerSelectListResponseViewModel(string ID, string Name);
    public class ManagerSelectListResponseProfile : Profile
    {
        public ManagerSelectListResponseProfile()
        {
            CreateMap<CandidateSelectListDTO, ManagerSelectListResponseViewModel>();
        }
    }
}
