using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.Medias.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Levels.GetCandidateSignature
{
    public class GetCandidateSignatureEndpoint : EndpointBase<GetCandidateSignatureRequestViewModel, GetCandidateSignatureResponseViewModel>
    {
        public GetCandidateSignatureEndpoint(EndpointBaseParameters<GetCandidateSignatureRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetCandidateSignature })]
        public async Task<EndPointResponse<GetCandidateSignatureResponseViewModel>> GetCandidateSignature([FromQuery] GetCandidateSignatureRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetMediaForAnySourceQuery>());

            GetCandidateSignatureResponseViewModel response = result.Data.MapOne<GetCandidateSignatureResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetCandidateSignatureResponseViewModel>.Success(response, "Get Candidate Signature successfully.");
            else
                return EndPointResponse<GetCandidateSignatureResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
