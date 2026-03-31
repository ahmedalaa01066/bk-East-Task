using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Managements.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Managements.SelectManagementList
{
    public class SelectManagementListEndpoint : EndpointBase<SelectManagementListRequestViewModel, SelectManagementListResponseViewModel>
    {
        public SelectManagementListEndpoint(EndpointBaseParameters<SelectManagementListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.SelectManagementList })]
        public async Task<EndPointResponse<IEnumerable<SelectManagementListResponseViewModel>>> SelectManagementList([FromQuery] SelectManagementListRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<SelectManagementListQuery>());

            var response = result.Data.MapList<SelectManagementListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<SelectManagementListResponseViewModel>>.Success(response, "Managements filtered successfully.");
            else
                return EndPointResponse<IEnumerable<SelectManagementListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
