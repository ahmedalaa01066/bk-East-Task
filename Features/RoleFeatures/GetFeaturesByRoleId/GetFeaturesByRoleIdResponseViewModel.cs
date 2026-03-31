using AutoMapper;

namespace EasyTask.Features.RoleFeatures.GetFeaturesByRoleId
{
    public record GetFeaturesByRoleIdResponseViewModel(List<int> FeatureIds);
    
        public class GetFeaturesByRoleIdResponseProfile : Profile
        {
            public GetFeaturesByRoleIdResponseProfile()
            {
            CreateMap<List<int>, GetFeaturesByRoleIdResponseViewModel>()
                       .ConstructUsing(src => new GetFeaturesByRoleIdResponseViewModel(src));
        }
        }
    
}
