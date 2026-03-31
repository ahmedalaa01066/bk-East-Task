using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Positions.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Positions.GetPositionById
{
    public class GetPositionByIdEndpoint : EndpointBase<GetPositionByIdRequestViewModel, GetPositionByIdResponseViewModel>
    {
        public GetPositionByIdEndpoint(EndpointBaseParameters<GetPositionByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetPositionById })]
        public async Task<EndPointResponse<GetPositionByIdResponseViewModel>> GetByID([FromQuery] GetPositionByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetPositionByIdQuery>());

            GetPositionByIdResponseViewModel response = result.Data.MapOne<GetPositionByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetPositionByIdResponseViewModel>.Success(response, "Get Position successfully.");
            else
                return EndPointResponse<GetPositionByIdResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
