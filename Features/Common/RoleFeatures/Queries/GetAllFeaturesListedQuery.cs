using EasyTask.Common.Requests;
using EasyTask.Features.Common.RoleFeatures.DTOs;
using EasyTask.Models.Enums;
using EasyTask.Models.RoleFeatures;

namespace EasyTask.Features.Common.RoleFeatures.Queries
{
    public record GetAllFeaturesListedQuery(int RoleID, string? FeatureName) : IRequestBase<List<GetAllFeaturesListedDTO>>;

    public class GetAllFeaturesListedQueryHandler : RequestHandlerBase<RoleFeature, GetAllFeaturesListedQuery, List<GetAllFeaturesListedDTO>>
    {
        public GetAllFeaturesListedQueryHandler(RequestHandlerBaseParameters<RoleFeature> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<GetAllFeaturesListedDTO>>> Handle(GetAllFeaturesListedQuery request, CancellationToken cancellationToken)
        {
            var sectionRanges = new Dictionary<string, (int Start, int End)>
            {
                { "Management Features", (1, 999) },
                { "Department Features", (1000, 1999) },
                { "Governorate Features", (2000, 2999) },
                { "Role Features", (3000, 3999) },
                { "Candidate Features", (4000, 4999) },
                { "Position Features", (5000, 5999) },
                { "Media Features", (6000, 6999) },
                { "Document Features", (7000, 7999) },
                { "General Features", (8000, 8999) },
                { "Level Features", (9000, 9999) },
                { "Notification Features", (10000, 10999) },
                { "Penalty Features", (11000, 11999) },
                { "Course Features", (12000, 12999) },
                { "KPI Features", (13000, 13999) },
                { "Default KPI Features", (14000, 14999) },
                { "Shift Features", (15000, 15999) },
                { "Attendance & PauseShift Features", (16000, 16999) },
                { "Vacation Features", (17000, 17999) },
                { "Vacation Request Features", (18000, 18999) },
                { "Permission Features", (19000, 19999) },
                { "Permission Request Features", (20000, 20999) },
                { "Candidate Vacation Features", (21000, 21999) },
                { "Special Day Features", (22000, 22999) },
                { "Job Features", (23000, 23999) }
            };



            var allFeatures = Enum.GetValues(typeof(Feature))
                .Cast<Feature>()
                .Where(feature => string.IsNullOrWhiteSpace(request.FeatureName) ||
                                  feature.ToString().IndexOf(request.FeatureName, StringComparison.OrdinalIgnoreCase) >= 0);

            var groupedFeatures = sectionRanges.Select(section => new GetAllFeaturesListedDTO
            {
                SectionName = section.Key,
                Features = allFeatures
                    .Where(feature => (int)feature >= section.Value.Start && (int)feature <= section.Value.End)
                    .Select(feature => new RoleActiveFeatuersDTO
                    {
                        FeatureId = (int)feature,
                        IsActiveToRole = (_mediator.Send(new CheckIsFeatureAssignedToRoleQuery((int)feature, request.RoleID))).Result.Data
                    }).ToList()
            }).Where(dto => dto.Features.Any())
              .ToList();

            return RequestResult<List<GetAllFeaturesListedDTO>>.Success(groupedFeatures);
        }

    }
}