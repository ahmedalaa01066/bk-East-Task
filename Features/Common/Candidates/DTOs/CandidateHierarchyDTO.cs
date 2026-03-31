using AutoMapper;
using EasyTask.Models.Candidates;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public class CandidateHierarchyDTO
    {
        public string CandidateID { get; set; }
        public string CandidateName { get; set; }
        public string LevelId { get; set; }
        public string LevelName { get; set; }
        public int LevelSeq { get; set; }
        public string ManagementId { get; set; }
        public string ManagementName { get; set; }
        public List<CandidateHierarchyDTO>? CandidateThirdLevel { get; set; } = new();
    }
    public class CandidateHierarchyDTOProfile : Profile
    {
        public CandidateHierarchyDTOProfile()
        {
            CreateMap<Candidate, CandidateHierarchyDTO>()
                  .ForMember(dest => dest.CandidateID, opt => opt.MapFrom(src => src.ID))
                  .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => string.Concat(src.FirstName, " ", src.LastName)))
                  .ForMember(dest => dest.LevelId, opt => opt.MapFrom(src => src.LevelId))
                  .ForMember(dest => dest.LevelName, opt => opt.MapFrom(src => src.Level.Name))
                  .ForMember(dest => dest.LevelSeq, opt => opt.MapFrom(src => src.Level.Sequence))
                  .ForMember(dest => dest.ManagementId, opt => opt.MapFrom(src => src.ManagementId))
                  .ForMember(dest => dest.ManagementName, opt => opt.MapFrom(src => src.Management.Name));
        }
    }
}
