using EasyTask.Common.Endpoints;
using EasyTask.Features.Users.ResendOTP.Orchestrators;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Users.ResendOTP
{
    public class ResendOTPEndPoint : EndpointBase<ResendOTPRequestViewModel, ResendOTPResponseViewModel>
    {
        public ResendOTPEndPoint(EndpointBaseParameters<ResendOTPRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        // [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ResendOTP })]
        public async Task<EndPointResponse<ResendOTPResponseViewModel>> Post(ResendOTPRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<ResendOTPOrchestrator>());
            if (result.IsSuccess)
            {
                return EndPointResponse<ResendOTPResponseViewModel>.Success(result.Data.MapOne<ResendOTPResponseViewModel>(), result.Message);
            }
            return EndPointResponse<ResendOTPResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
