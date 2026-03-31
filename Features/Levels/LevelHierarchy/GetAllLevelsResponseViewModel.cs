using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Features.Common.Levels.DTOs;
using EasyTask.Features.Common.Managements.DTOs;

namespace EasyTask.Features.Levels.LevelHierarchy
{
    public class LevelHierarchyResponseViewModel
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
    public class LevelHierarchyResponseProfile : Profile
    {
        public LevelHierarchyResponseProfile()
        {
            CreateMap<LevelHierarchyDTO, LevelHierarchyResponseViewModel>();
        }
    }
}
