using EasyTask.Common.Endpoints;
using EasyTask.Features.Users.GetVerifyStatusList.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Users.GetVerifyStatusList
{
    public class GetVerifyStatusListEndpoint : EndpointBase<GetVerifyStatusListRequestViewModel, GetVerifyStatusListResponseViewModel>
    {
        public GetVerifyStatusListEndpoint(EndpointBaseParameters<GetVerifyStatusListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
       // [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetVerifyStatusList})]
        public async Task<EndPointResponse<IEnumerable<GetVerifyStatusListResponseViewModel>>> SelectList([FromQuery] GetVerifyStatusListRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetVerifyStatusListQuery>());

            var response = result.Data.MapList<GetVerifyStatusListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<GetVerifyStatusListResponseViewModel>>.Success(response, "Get all verify status list successfully.");
            else
                return EndPointResponse<IEnumerable<GetVerifyStatusListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
