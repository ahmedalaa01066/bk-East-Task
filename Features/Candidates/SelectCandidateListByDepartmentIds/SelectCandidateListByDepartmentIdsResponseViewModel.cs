using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Candidates.SelectCandidateListByDepartmentIds
{
    public record SelectCandidateListByDepartmentIdsResponseViewModel(string ID, string Name, Assignment Assignment);
    public class SelectCandidateListByDepartmentIdsResponseProfile : Profile
    {
        public SelectCandidateListByDepartmentIdsResponseProfile()
        {
            CreateMap<SelectCandidateListByDepartmentIdsDTO, SelectCandidateListByDepartmentIdsResponseViewModel>();
        }
    }
}
