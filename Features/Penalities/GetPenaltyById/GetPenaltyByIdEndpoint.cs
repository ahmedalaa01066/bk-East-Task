using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Penalities.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Penalities.GetPenaltyById
{
    public class GetPenaltyByIdEndpoint : EndpointBase<GetPenaltyByIdRequestViewModel, GetPenaltyByIdResponseViewModel>
    {
        public GetPenaltyByIdEndpoint(EndpointBaseParameters<GetPenaltyByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetPenaltyById })]
        public async Task<EndPointResponse<GetPenaltyByIdResponseViewModel>> GetPenaltyById([FromQuery] GetPenaltyByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetPenaltyByIdQuery>());

            GetPenaltyByIdResponseViewModel response = result.Data.MapOne<GetPenaltyByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetPenaltyByIdResponseViewModel>.Success(response, "Get Penalty successfully.");
            else
                return EndPointResponse<GetPenaltyByIdResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
