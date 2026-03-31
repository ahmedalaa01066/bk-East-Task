using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Candidates.GetManagerByCandidateId
{
    public class GetManagerByCandidateIdEndpoint : EndpointBase<GetManagerByCandidateIdRequestViewModel, GetManagerByCandidateIdResponseViewModel>
    {
        public GetManagerByCandidateIdEndpoint(EndpointBaseParameters<GetManagerByCandidateIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetManagerByCandidateId })]
        public async Task<EndPointResponse<GetManagerByCandidateIdResponseViewModel>> GetManagerByCandidateId([FromQuery] GetManagerByCandidateIdRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetManagerByCandidateIdQuery>());

            GetManagerByCandidateIdResponseViewModel response = result.Data.MapOne<GetManagerByCandidateIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetManagerByCandidateIdResponseViewModel>.Success(response, "Get Manager successfully.");
            else
                return EndPointResponse<GetManagerByCandidateIdResponseViewModel>.Failure(result.ErrorCode,result.Message);

        }
    }
}
