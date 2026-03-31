using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.RoleFeatures;

namespace EasyTask.Features.Common.RoleFeatures.Queries
{
    public record SearchFeatureByNameQuery(string? FeatureName) :IRequestBase<IEnumerable<Feature>>;
    public class SearchFeatureByNameQueryHandler : RequestHandlerBase<RoleFeature, SearchFeatureByNameQuery, IEnumerable<Feature>>
    {
        public SearchFeatureByNameQueryHandler(RequestHandlerBaseParameters<RoleFeature> requestParameters) : base(requestParameters)
        {
        }
        public override async Task<RequestResult<IEnumerable<Feature>>> Handle(SearchFeatureByNameQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.FeatureName))
            {
                return RequestResult<IEnumerable<Feature>>.Success(Enumerable.Empty<Feature>());
            }

            IEnumerable<Feature> Featuers = EnumHelper.SearchEnumByName<Feature>(request.FeatureName);
            return RequestResult<IEnumerable<Feature>>.Success(Featuers);
        }
    }
}
