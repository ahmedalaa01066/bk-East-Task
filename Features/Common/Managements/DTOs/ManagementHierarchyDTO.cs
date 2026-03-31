using AutoMapper;
using EasyTask.Models.Managements;

namespace EasyTask.Features.Common.Managements.DTOs
{
    public class ManagementHierarchyDTO
    {
        public string ManagementID { get; set; }
        public string ManagementName { get; set; }
        public string ManagerName { get; set; }
        public List<string> CandidateFullNames { get; set; } = new();
    }
    public class ManagementHierarchyDTOProfile : Profile
    {
        public ManagementHierarchyDTOProfile()
        {
            CreateMap<Management, ManagementHierarchyDTO>()
                  .ForMember(dest => dest.ManagementID, opt => opt.MapFrom(src => src.ID))
                  .ForMember(dest => dest.ManagementName, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => string.Concat(src.Manager.FirstName, src.Manager.LastName)));
        }
    }
}
