using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Common.Users.Queries;
using EasyTask.Helpers;
using Microsoft.IdentityModel.Tokens;
using EasyTask.Models.Enums;
using EasyTask.Middlewares;

namespace EasyTask.Features.Users.CheckOTPValidation
{
    public class CheckOTPValidationEndpoint : EndpointBase<CheckOTPValidationRequestViewModel, CheckOTPValidationResponseViewModel>
    {
        public CheckOTPValidationEndpoint(EndpointBaseParameters<CheckOTPValidationRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpGet]
      //  [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CheckOTPValidation })]
        public async Task<EndPointResponse<CheckOTPValidationResponseViewModel>> CheckOTPValidation([FromQuery] CheckOTPValidationRequestViewModel viewModel)
        {
            var userID = await _mediator.Send(viewModel.MapOne<CheckOTPValidationQuery>());

            if (!userID.Data.IsNullOrEmpty())
            {
                return EndPointResponse<CheckOTPValidationResponseViewModel>
                    .Success(userID.Data.MapOne<CheckOTPValidationResponseViewModel>(), "OTP Verified successfully");
            }

            return EndPointResponse<CheckOTPValidationResponseViewModel>.Failure(userID.ErrorCode);

        }
    }
}
