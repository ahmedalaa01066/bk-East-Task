using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.RoleFeatures;

namespace EasyTask.Features.RoleFeatures.UnassignBulkFeaturesFromRole.Commands
{
    public record UnassignBulkFeaturesFromRoleCommand(Role RoleId, IEnumerable<Feature> Features) : IRequestBase<bool>;

    public class UnassignBulkFeaturesFromRoleCommandHandler : RequestHandlerBase<RoleFeature, UnassignBulkFeaturesFromRoleCommand, bool>
    {
        public UnassignBulkFeaturesFromRoleCommandHandler(RequestHandlerBaseParameters<RoleFeature> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(UnassignBulkFeaturesFromRoleCommand request, CancellationToken cancellationToken)
        {
            if (!Enum.IsDefined(typeof(Role), request.RoleId))
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            var featuresToRemove = _repository
                .Get(rf => rf.RoleId == request.RoleId && request.Features.Contains(rf.Features))
                .ToList();

            if (featuresToRemove.Any())
            {
                foreach (var feature in featuresToRemove)
                {
                    _repository.Delete(feature); 
                }

                 _repository.SaveChanges();
            }

            return RequestResult<bool>.Success(true);
        }
    }
}
