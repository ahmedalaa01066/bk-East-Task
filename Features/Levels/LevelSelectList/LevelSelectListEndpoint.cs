using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Levels.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Levels.LevelSelectList
{
    public class LevelSelectListEndpoint : EndpointBase<LevelSelectListRequestViewModel, LevelSelectListResponseViewModel>
    {
        public LevelSelectListEndpoint(EndpointBaseParameters<LevelSelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.LevelSelectList })]
        public async Task<EndPointResponse<IEnumerable<LevelSelectListResponseViewModel>>> SelectLevelList([FromQuery] LevelSelectListRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<LevelSelectListQuery>());

            var response = result.Data.MapList<LevelSelectListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<LevelSelectListResponseViewModel>>.Success(response, "Levels got successfully.");
            else
                return EndPointResponse<IEnumerable<LevelSelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
