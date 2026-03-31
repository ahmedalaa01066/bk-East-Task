using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Departments.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Departments.SelectDepartmentList
{
    public class SelectDepartmentListEndPoint : EndpointBase<SelectDepartmentListRequestViewModel, SelectDepartmentListResponseViewModel>
    {
        public SelectDepartmentListEndPoint(EndpointBaseParameters<SelectDepartmentListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.SelectDepartmentList })]
        public async Task<EndPointResponse<IEnumerable<SelectDepartmentListResponseViewModel>>> SelectDepartmentList([FromQuery] SelectDepartmentListRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<SelectDepartmentListQuery>());

            var response = result.Data.MapList<SelectDepartmentListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<SelectDepartmentListResponseViewModel>>.Success(response, "Departments filtered successfully.");
            else
                return EndPointResponse<IEnumerable<SelectDepartmentListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
