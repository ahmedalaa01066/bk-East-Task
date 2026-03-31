using AutoMapper;
using EasyTask.Models.Jobs;

namespace EasyTask.Features.Common.Jobs.DTOs
{
    public class GetAllJobsDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string JobCode { get; set; }
        public string ManagementId { get; set; }
        public string ManagementName { get; set; }
    }
    public class GetAllJobsDTOProfile : Profile
    {
        public GetAllJobsDTOProfile()
        {
            CreateMap<Job, GetAllJobsDTO>()
               .ForMember(dest => dest.ManagementName, opt => opt.MapFrom(src => src.Management.Name));
        }
    }
}
