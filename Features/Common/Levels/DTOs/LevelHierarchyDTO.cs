using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Models.Levels;

namespace EasyTask.Features.Common.Levels.DTOs
{
    public class LevelHierarchyDTO
    {
        public string LevelId { get; set; }
        public string LevelName { get; set; }
        public int Sequence { get; set; }
        public string CandidateID { get; set; }
        public string CandidateName { get; set; }
        public string? ManagementId { get; set; }
        public string? ManagementName { get; set; }
        public List<CandidateHierarchyDTO>? Candidates { get; set; } = new();
    }
    public class LevelHierarchyDTOProfile : Profile
    {
        public LevelHierarchyDTOProfile()
        {
            CreateMap<Level,LevelHierarchyDTO>()
                  .ForMember(dest => dest.LevelId, opt => opt.MapFrom(src => src.ID))
                  .ForMember(dest => dest.Sequence, opt => opt.MapFrom(src => src.Sequence))
                  .ForMember(dest => dest.LevelName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
