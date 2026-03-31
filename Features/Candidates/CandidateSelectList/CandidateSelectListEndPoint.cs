using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.CandidateSelectList
{
    public class CandidateSelectListEndPoint : EndpointBase<CandidateSelectListRequestViewModel, CandidateSelectListResponseViewModel>
    {
        public CandidateSelectListEndPoint(EndpointBaseParameters<CandidateSelectListRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.SelectCandidateList })]
        public async Task<EndPointResponse<IEnumerable<CandidateSelectListResponseViewModel>>> SelectCandidateList([FromQuery] CandidateSelectListRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<CandidateSelectListQuery>());

            var response = result.Data.MapList<CandidateSelectListResponseViewModel>();

            if (result.IsSuccess)
                return EndPointResponse<IEnumerable<CandidateSelectListResponseViewModel>>.Success(response, "candidates got successfully.");
            else
                return EndPointResponse<IEnumerable<CandidateSelectListResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
