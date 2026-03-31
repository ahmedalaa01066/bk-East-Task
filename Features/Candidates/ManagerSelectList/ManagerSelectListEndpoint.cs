using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.ManagerSelectList
{
    public class ManagerSelectListEndpoint : EndpointBase<ManagerSelectListRequestViewModel, ManagerSelectListResponseViewModel>
    {
        public ManagerSelectListEndpoint(EndpointBaseParameters<ManagerSelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ManagerSelectList })]
        public async Task<EndPointResponse<IEnumerable<ManagerSelectListResponseViewModel>>> ManagerSelectList([FromQuery] ManagerSelectListRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<ManagerSelectListQuery>());

            var response = result.Data.MapList<ManagerSelectListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<ManagerSelectListResponseViewModel>>.Success(response, "Manager got successfully.");
            else
                return EndPointResponse<IEnumerable<ManagerSelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
