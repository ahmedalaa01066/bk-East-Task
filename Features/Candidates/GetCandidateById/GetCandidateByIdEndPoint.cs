using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.SetCandidateById
{
    public class GetCandidateByIdEndPoint : EndpointBase<GetCandidateByIdRequestViewModel, GetCandidateByIdResponseViewModel>
    {
        public GetCandidateByIdEndPoint(EndpointBaseParameters<GetCandidateByIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetCandidateById })]
        public async Task<EndPointResponse<GetCandidateByIdResponseViewModel>> GetCandidateById([FromQuery] GetCandidateByIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetCandidateByIdQuery>());

            GetCandidateByIdResponseViewModel response = result.Data.MapOne<GetCandidateByIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetCandidateByIdResponseViewModel>.Success(response, "Get Candidate successfully.");
            else
                return EndPointResponse<GetCandidateByIdResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
