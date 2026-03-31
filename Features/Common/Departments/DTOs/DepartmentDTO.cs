using AutoMapper;
using EasyTask.Models.Departments;

namespace EasyTask.Features.Common.Departments.DTOs
{
    public class DepartmentDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int CandidateCount { get; set; }
    }
    public class DepartmentDTOProfile : Profile
    {
        public DepartmentDTOProfile()
        {
            CreateMap<Department, DepartmentDTO>()
                .ForMember(dest => dest.CandidateCount, opt => opt.MapFrom(src =>
                    src.Candidates != null ? src.Candidates.Count(c => c.Deleted == false) : 0));
        }
    }

}
