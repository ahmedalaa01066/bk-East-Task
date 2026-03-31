using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.SelectCandidateListByDepartmentIds
{
    public class SelectCandidateListByDepartmentIdsEndPoint : EndpointBase<SelectCandidateListByDepartmentIdsRequestViewModel, SelectCandidateListByDepartmentIdsResponseViewModel>
    {
        public SelectCandidateListByDepartmentIdsEndPoint(EndpointBaseParameters<SelectCandidateListByDepartmentIdsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.SelectCandidateListByDepartmentIds })]
        public async Task<EndPointResponse<IEnumerable<SelectCandidateListByDepartmentIdsResponseViewModel>>>
            SelectCandidateListByDepartmentIds([FromQuery] SelectCandidateListByDepartmentIdsRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<SelectCandidateListByDepartmentIdsQuery>());

            var response = result.Data.MapList<SelectCandidateListByDepartmentIdsResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<SelectCandidateListByDepartmentIdsResponseViewModel>>.Success(response, "Candidates filtered successfully.");
            else
                return EndPointResponse<IEnumerable<SelectCandidateListByDepartmentIdsResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
