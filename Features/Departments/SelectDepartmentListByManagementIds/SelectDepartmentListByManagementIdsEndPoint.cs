using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Departments.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Departments.SelectDepartmentListByManagementIds
{
    public class SelectDepartmentListByManagementIdsEndPoint : EndpointBase<SelectDepartmentListByManagementIdsRequestViewModel, SelectDepartmentListByManagementIdsResponseViewModel>
    {
        public SelectDepartmentListByManagementIdsEndPoint(EndpointBaseParameters<SelectDepartmentListByManagementIdsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.SelectDepartmentListByManagementIds })]
        public async Task<EndPointResponse<IEnumerable<SelectDepartmentListByManagementIdsResponseViewModel>>>
            SelectDepartmentListByManagementIds([FromQuery] SelectDepartmentListByManagementIdsRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<SelectDepartmentListByManagementIdsQuery>());

            var response = result.Data.MapList<SelectDepartmentListByManagementIdsResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<SelectDepartmentListByManagementIdsResponseViewModel>>.Success(response, "Departments filtered successfully.");
            else
                return EndPointResponse<IEnumerable<SelectDepartmentListByManagementIdsResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
