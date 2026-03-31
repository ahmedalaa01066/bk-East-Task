using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Managements.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Managements.SelectManagementListByCourseId
{
    public class SelectManagementListByCourseIdEndPoint : EndpointBase<SelectManagementListByCourseIdRequestViewModel, SelectManagementListByCourseIdResponseViewModel>
    {
        public SelectManagementListByCourseIdEndPoint(EndpointBaseParameters<SelectManagementListByCourseIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.SelectManagementListByCourseId })]
        public async Task<EndPointResponse<IEnumerable<SelectManagementListByCourseIdResponseViewModel>>>
            SelectManagementListByCourseId([FromQuery] SelectManagementListByCourseIdRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<SelectManagementListByCourseIdQuery>());

            var response = result.Data.MapList<SelectManagementListByCourseIdResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<SelectManagementListByCourseIdResponseViewModel>>.Success(response, "Managements filtered successfully.");
            else
                return EndPointResponse<IEnumerable<SelectManagementListByCourseIdResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
