using AutoMapper;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public class SelectCandidateListByDepartmentIdsDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Assignment Assignment { get; set; }
    };
    public class SelectCandidateListByDepartmentIdsDTOProfile : Profile
    {
        public SelectCandidateListByDepartmentIdsDTOProfile()
        {
            CreateMap<Candidate, SelectCandidateListByDepartmentIdsDTO>()
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName}  {src.LastName}"));
        }
    }
}
