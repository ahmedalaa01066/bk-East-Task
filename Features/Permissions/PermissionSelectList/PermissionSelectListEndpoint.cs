using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Permissions.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Permissions.PermissionSelectList
{
    public class PermissionSelectListEndpoint : EndpointBase<PermissionSelectListRequestViewModel, PermissionSelectListResponseViewModel>
    {
        public PermissionSelectListEndpoint(EndpointBaseParameters<PermissionSelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.PermissionSelectList })]
        public async Task<EndPointResponse<IEnumerable<PermissionSelectListResponseViewModel>>> PermissionSelectList([FromQuery] PermissionSelectListRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<PermissionSelectListQuery>());

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<PermissionSelectListResponseViewModel>>.Success(result.Data.MapList<PermissionSelectListResponseViewModel>(), "Permissions got successfully.");
            else
                return EndPointResponse<IEnumerable<PermissionSelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
