using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Features.Common.Levels.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Levels.LevelHierarchy
{
    public class LevelHierarchyEndpoint : EndpointBase<LevelHierarchyRequestViewModel, LevelHierarchyResponseViewModel>
    {
        public LevelHierarchyEndpoint(EndpointBaseParameters<LevelHierarchyRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.LevelHierarchy })]
        public async Task<ActionResult<EndPointResponse<IEnumerable<LevelHierarchyResponseViewModel>>>> LevelHierarchy([FromQuery] LevelHierarchyRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<LevelHierarchyQuery>());
            var response = result.Data.MapList<LevelHierarchyResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {
                return EndPointResponse<IEnumerable<LevelHierarchyResponseViewModel>>
                    .Success(response, "Levels filtered successfully.");
            }

            return EndPointResponse<IEnumerable<LevelHierarchyResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
