using AutoMapper;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.RoleFeatures.DTOs
{
    public class GetFeaturesByRoleIdProfileDTO
    {
       public int FeatureId { get; set; }
       public string FeatureName => ((Feature)FeatureId).ToString();
    }
    public class GetFeaturesByRoleIdProfile : Profile
    {
        public GetFeaturesByRoleIdProfile()
        {
            CreateMap<Feature, GetFeaturesByRoleIdProfileDTO>()
            .ForMember(dest => dest.FeatureId, opt => opt.MapFrom(src => src));
            CreateMap<GetFeaturesByRoleIdProfileDTO, GetAllFeaturesListedDTO>();
        }
    }
}
