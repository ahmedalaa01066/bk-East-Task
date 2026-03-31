using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.RoleFeatures;

namespace EasyTask.Features.RoleFeatures.AssignAllFeaturesToRole.Commands
{
    public record AssignAllFeaturesToRoleCommand() : IRequestBase<bool>;
    public class AssignAllFeaturesToRoleCommandHandler : RequestHandlerBase<RoleFeature, AssignAllFeaturesToRoleCommand, bool>
    {
        public AssignAllFeaturesToRoleCommandHandler(RequestHandlerBaseParameters<RoleFeature> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AssignAllFeaturesToRoleCommand request, CancellationToken cancellationToken)
        {
            if (!Enum.IsDefined(typeof(Role), Role.Candidate))
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            var allFeatures = Enum.GetValues(typeof(Feature)).Cast<Feature>().ToList();

            var selectableFeatures = EnumHelper.ToSelectableList<Feature>();

            var assignedFeatures = _repository
                .Get(rf => rf.RoleId == Role.Candidate)
                .Select(rf => rf.Features)
                .ToList();
            List<RoleFeature> roleFeatures = new List<RoleFeature>();
            var newFeatures = allFeatures.Except(assignedFeatures).ToList();

            foreach (var feature in newFeatures)
            {
                var roleFeature = new RoleFeature
                {
                    RoleId = Role.Candidate,
                    Features = feature
                };

                roleFeatures.Add(roleFeature);
            }
            _repository.AddRange(roleFeatures);
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
