using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Managements.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Managements.GetManagementByID
{
    public class GetManagementByIDEndPoint : EndpointBase<GetManagementByIDRequestViewModel, GetManagementByIDResponseViewModel>
    {
        public GetManagementByIDEndPoint(EndpointBaseParameters<GetManagementByIDRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetManagementByID })]
        public async Task<EndPointResponse<GetManagementByIDResponseViewModel>> GetManagementByID([FromQuery] GetManagementByIDRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetManagementByIDQuery>());

            var response = result.Data.MapOne<GetManagementByIDResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetManagementByIDResponseViewModel>.Success(response, "Get Management By ID successfully.");
            else
                return EndPointResponse<GetManagementByIDResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
