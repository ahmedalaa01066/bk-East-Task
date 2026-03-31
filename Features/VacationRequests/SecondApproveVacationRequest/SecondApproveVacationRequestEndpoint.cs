using EasyTask.Common.Endpoints;
using EasyTask.Features.VacationRequests.SecondApproveVactionRequest.Orchestrator;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.VacationRequests.SecondApproveVactionRequest
{
    public class SecondApproveVacationRequestEndpoint : EndpointBase<SecondApproveVacationRequestRequestViewModel, SecondApproveVacationRequestResponseViewModel>
    {
        public SecondApproveVacationRequestEndpoint(EndpointBaseParameters<SecondApproveVacationRequestRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.SecondApproveVacationRequest })]
        public async Task<EndPointResponse<SecondApproveVacationRequestResponseViewModel>> SecondApproveVacationRequest(SecondApproveVacationRequestRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<SecondApproveVacationRequestOrchestrator>());
            if (result.IsSuccess)
                return EndPointResponse<SecondApproveVacationRequestResponseViewModel>.Success(new SecondApproveVacationRequestResponseViewModel(), "Vacation Request Approved Successfully");
            else
                return EndPointResponse<SecondApproveVacationRequestResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}