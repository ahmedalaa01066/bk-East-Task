using AutoMapper;
using EasyTask.Features.Common.RoleFeatures.Queries;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.RoleFeatures.DTOs
{
    public class GetAllFeaturesListedDTO
    {
        public string SectionName { get; set; }
        public List<RoleActiveFeatuersDTO> Features{ get; set; }
    }
    public class GetAllFeaturesListedDTOProfile : Profile
    {
        public GetAllFeaturesListedDTOProfile()
        {
            CreateMap<Feature, GetAllFeaturesListedDTO>();
            CreateMap<GetAllFeaturesListedDTO, RoleActiveFeatuersDTO>();
        }
    }
}
