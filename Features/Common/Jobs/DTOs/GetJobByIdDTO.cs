using AutoMapper;
using EasyTask.Models.Jobs;

namespace EasyTask.Features.Common.Jobs.DTOs
{
    public record GetJobByIdDTO(string ID, string Name, string Description, string ManagementId, string ManagementName);
    public class GetJobByIdDTOProfile : Profile
    {
        public GetJobByIdDTOProfile()
        {
            CreateMap<Job, GetJobByIdDTO>()
               .ForMember(dest => dest.ManagementName, opt => opt.MapFrom(src => src.Management.Name));
        }
    }
}
