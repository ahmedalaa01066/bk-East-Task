using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.VacationRequests.Queries;
using EasyTask.Features.VacationRequests.GetVacationRequestById;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.VacationRequests.GetByIdVacationRequest
{
    public class GetVacationRequestByIdEndpoint : EndpointBase<GetVacationRequestByIdRequestViewModel, GetVacationRequestByIdResponseViewModel>
    {
        public GetVacationRequestByIdEndpoint(EndpointBaseParameters<GetVacationRequestByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetVacationRequestByID })]
        public async Task<EndPointResponse<GetVacationRequestByIdResponseViewModel>> GetVacationRequestByID([FromQuery] GetVacationRequestByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetVacationRequestByIdQuery>());

            var response = result.Data.MapOne<GetVacationRequestByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetVacationRequestByIdResponseViewModel>.Success(response, "Get Vacation Request successfully.");
            else
                return EndPointResponse<GetVacationRequestByIdResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
