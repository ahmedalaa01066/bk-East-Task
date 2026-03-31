using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.RoleFeatures;

namespace EasyTask.Features.Common.RoleFeatures
{
    public record CheckRoleFeatureAccessQuery(Role RoleId, Feature Feature) : IRequestBase<bool>;
    public class CheckRoleFeatureAccessQueryHandler : RequestHandlerBase<RoleFeature, CheckRoleFeatureAccessQuery, bool>
    {
        public CheckRoleFeatureAccessQueryHandler(RequestHandlerBaseParameters<RoleFeature> requestParameters)
            : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CheckRoleFeatureAccessQuery request, CancellationToken cancellationToken)
        {
            
            bool hasAccess = _repository.Any(rf => rf.RoleId == request.RoleId && rf.Features==request.Feature);
            return RequestResult<bool>.Success(hasAccess);
        }
    }

}
