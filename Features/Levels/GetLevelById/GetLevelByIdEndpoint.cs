using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Levels.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Levels.GetLevelById
{
    public class GetLevelByIdEndpoint : EndpointBase<GetLevelByIdRequestViewModel, GetLevelByIdResponseViewModel>
    {
        public GetLevelByIdEndpoint(EndpointBaseParameters<GetLevelByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetLevelById })]
        public async Task<EndPointResponse<GetLevelByIdResponseViewModel>> GetLevelById([FromQuery] GetLevelByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetLevelByIdQuery>());

            GetLevelByIdResponseViewModel response = result.Data.MapOne<GetLevelByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetLevelByIdResponseViewModel>.Success(response, "Get Level successfully.");
            else
                return EndPointResponse<GetLevelByIdResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
