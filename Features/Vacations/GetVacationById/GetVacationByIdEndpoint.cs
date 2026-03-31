using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Vacations.Queries;
using EasyTask.Features.Vacations.GetVacationById;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Vacations.GetByIdVacation
{
    public class GetVacationByIdEndpoint : EndpointBase<GetVacationByIdRequestViewModel, GetVacationByIdResponseViewModel>
    {
        public GetVacationByIdEndpoint(EndpointBaseParameters<GetVacationByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetVacationById })]
        public async Task<EndPointResponse<GetVacationByIdResponseViewModel>> GetByID([FromQuery] GetVacationByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetVacationByIdQuery>());

            var response = result.Data.MapOne<GetVacationByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetVacationByIdResponseViewModel>.Success(response, "Get Vacation successfully.");
            else
                return EndPointResponse<GetVacationByIdResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
