using EasyTask.Common.Requests;
using EasyTask.Data;
using EasyTask.Features.Common.RoleFeatures.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.RoleFeatures;
using System.Collections.Generic;

namespace EasyTask.Features.Common.RoleFeatures.GetFeaturesByRoleId
{
    public record GetFeaturesByRoleIdQuery(Role RoleId) : IRequestBase<IEnumerable<GetFeaturesByRoleIdProfileDTO>>;

    public class GetFeaturesByRoleIdQueryHandler : RequestHandlerBase<RoleFeature, GetFeaturesByRoleIdQuery, IEnumerable<GetFeaturesByRoleIdProfileDTO>>
    {
        public GetFeaturesByRoleIdQueryHandler(RequestHandlerBaseParameters<RoleFeature> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<GetFeaturesByRoleIdProfileDTO>>> Handle(GetFeaturesByRoleIdQuery request, CancellationToken cancellationToken)
        {
            var featuresId = _repository
                .Get(rm => rm.RoleId == request.RoleId)
                .Select(rm => rm.Features)
                .ToList();
            IEnumerable<GetFeaturesByRoleIdProfileDTO> features = featuresId.MapList<GetFeaturesByRoleIdProfileDTO>();
         
            return RequestResult<IEnumerable<GetFeaturesByRoleIdProfileDTO>>.Success(features);
        }
    }
}
