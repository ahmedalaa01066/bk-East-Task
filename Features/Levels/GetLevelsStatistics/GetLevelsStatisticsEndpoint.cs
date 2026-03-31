using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Features.Common.Levels.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Levels.GetLevelsStatistics
{
    public class GetLevelsStatisticsEndpoint : EndpointBase<GetLevelsStatisticsRequestViewModel, GetLevelsStatisticsResponseViewModel>
    {
        public GetLevelsStatisticsEndpoint(EndpointBaseParameters<GetLevelsStatisticsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetLevelStatistics })]
        public async Task<ActionResult<EndPointResponse<IEnumerable<GetLevelsStatisticsResponseViewModel>>>> GetLevelStatistics([FromQuery] GetLevelsStatisticsRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetLevelsStatisticsQuery>());
            var response = result.Data.MapList<GetLevelsStatisticsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {
                return EndPointResponse<IEnumerable<GetLevelsStatisticsResponseViewModel>>
                    .Success(response, "Levels Statistics got successfully.");
            }

            return EndPointResponse<IEnumerable<GetLevelsStatisticsResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
