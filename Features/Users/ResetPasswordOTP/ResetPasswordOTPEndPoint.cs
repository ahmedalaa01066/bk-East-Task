using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Users.ResetPasswordOTP.Orchestrators;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Users.ResetPasswordOTP
{
    public class ResetPasswordOTPEndPoint : EndpointBase<ResetPasswordOTPRequestViewModel, ResetPasswordOTPResponseViewModel>
    {
        public ResetPasswordOTPEndPoint(EndpointBaseParameters<ResetPasswordOTPRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ResetPasswordOTP })]
        public async Task<EndPointResponse<ResetPasswordOTPResponseViewModel>> ResetPasswordOTP([FromQuery]ResetPasswordOTPRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<ResetPasswordOTPOrchestrator>());
            if (result.IsSuccess)
            {
                return EndPointResponse<ResetPasswordOTPResponseViewModel>.Success(result.Data.MapOne<ResetPasswordOTPResponseViewModel>(), result.Message);
            }
            return EndPointResponse<ResetPasswordOTPResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
