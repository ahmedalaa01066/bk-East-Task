using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.GetCandidateData
{
    public class GetCandidateDataEndPoint : EndpointBase<GetCandidateDataRequestViewModel, GetCandidateDataResponseViewModel>
    {
        public GetCandidateDataEndPoint(EndpointBaseParameters<GetCandidateDataRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetCandidateData })]
        public async Task<EndPointResponse<GetCandidateDataResponseViewModel>> GetCandidateData([FromQuery] GetCandidateDataRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetCandidateDataQuery>());

            GetCandidateDataResponseViewModel response = result.Data.MapOne<GetCandidateDataResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetCandidateDataResponseViewModel>.Success(response, "Get Candidate successfully.");
            else
                return EndPointResponse<GetCandidateDataResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
