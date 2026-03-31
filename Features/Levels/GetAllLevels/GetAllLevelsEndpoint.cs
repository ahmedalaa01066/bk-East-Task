using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Levels.DTOs;
using EasyTask.Features.Common.Levels.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Levels.GetLevelIndex
{
    public class GetAllLevelsEndpoint : EndpointBase<GetAllLevelsRequestViewModel, GetAllLevelsResponseViewModel>
    {
        public GetAllLevelsEndpoint(EndpointBaseParameters<GetAllLevelsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllLevels })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllLevelsResponseViewModel>>>> GetAllLevels(
         [FromQuery] GetAllLevelsRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllLevelsQuery>());
            var response = result.Data.MapPage<GetAllLevelsDTO, GetAllLevelsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllLevelsResponseViewModel>>
                    .Success(response, "Levels filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllLevelsResponseViewModel>>
                .Failure(ErrorCode.NotFound);
        }
    }
}
