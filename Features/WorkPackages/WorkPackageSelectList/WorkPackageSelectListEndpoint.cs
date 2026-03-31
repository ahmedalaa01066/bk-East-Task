using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.WorkPackages.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.WorkPackages.WorkPackageSelectList
{
    public class WorkPackageSelectListEndpoint : EndpointBase<WorkPackageSelectListRequestViewModel, WorkPackageSelectListResponseViewModel>
    {
        public WorkPackageSelectListEndpoint(EndpointBaseParameters<WorkPackageSelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.WorkPackageSelectList })]
        public async Task<EndPointResponse<IEnumerable<WorkPackageSelectListResponseViewModel>>> WorkPackageSelectList([FromQuery] WorkPackageSelectListRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<WorkPackageSelectListQuery>());

            var response = result.Data.MapList<WorkPackageSelectListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<WorkPackageSelectListResponseViewModel>>.Success(response, "WorkPackages got successfully.");
            else
                return EndPointResponse<IEnumerable<WorkPackageSelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
