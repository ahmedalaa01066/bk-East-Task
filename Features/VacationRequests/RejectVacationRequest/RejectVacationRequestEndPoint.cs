using EasyTask.Common.Endpoints;
using EasyTask.Features.VacationRequests.RejectVacationRequest.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.VacationRequests.RejectVacationRequest
{
    public class RejectVacationRequestEndPoint : EndpointBase<RejectVacationRequestRequestViewModel, RejectVacationRequestResponseViewModel>
    {
        public RejectVacationRequestEndPoint(EndpointBaseParameters<RejectVacationRequestRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.RejectVacationRequest })]
        public async Task<EndPointResponse<RejectVacationRequestResponseViewModel>> RejectVacationRequest(RejectVacationRequestRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<RejectVacationRequestCommand>());
            if (result.IsSuccess)
                return EndPointResponse<RejectVacationRequestResponseViewModel>.Success(new RejectVacationRequestResponseViewModel(), "Vacation Request Rejected Successfully");
            else
                return EndPointResponse<RejectVacationRequestResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
