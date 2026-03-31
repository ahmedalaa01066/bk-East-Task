using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Shifts.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Shifts.GetShiftById
{
    public class GetShiftByIdEndpoint : EndpointBase<GetShiftByIdRequestViewModel, GetShiftByIdResponseViewModel>
    {
        public GetShiftByIdEndpoint(EndpointBaseParameters<GetShiftByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetShiftByID })]
        public async Task<EndPointResponse<GetShiftByIdResponseViewModel>> GetByID([FromQuery] GetShiftByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetShiftByIDQuery>());

            var response = result.Data.MapOne<GetShiftByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetShiftByIdResponseViewModel>.Success(response, "Get Shift successfully.");
            else
                return EndPointResponse<GetShiftByIdResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
