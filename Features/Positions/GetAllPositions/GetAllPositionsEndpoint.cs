using EasyTask.Common.Endpoints;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Positions.DTOs;
using EasyTask.Features.Common.Positions.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Positions.GetAllPositions
{
    public class GetAllPositionsEndpoint : EndpointBase<GetAllPositionsRequestViewModel, GetAllPositionsResponseViewModel>
    {
        public GetAllPositionsEndpoint(EndpointBaseParameters<GetAllPositionsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetPositionsByName })]
        public async Task<EndPointResponse<PagingViewModel<GetAllPositionsResponseViewModel>>> GetByName([FromQuery] GetAllPositionsRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<GetAllPositionsQuery>());
            var response = result.Data.MapPage<GetAllPositionsDTO, GetAllPositionsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<PagingViewModel<GetAllPositionsResponseViewModel>>.Success(response, "Position Filtered Successfully");
            else
                return EndPointResponse<PagingViewModel<GetAllPositionsResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
