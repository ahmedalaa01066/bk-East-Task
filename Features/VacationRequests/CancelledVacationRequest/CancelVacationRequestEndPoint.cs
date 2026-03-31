using EasyTask.Common.Endpoints;
using EasyTask.Features.VacationRequests.CancelVacationRequest.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.VacationRequests.CancelVacationRequest
{
    public class CancelVacationRequestEndPoint : EndpointBase<CancelVacationRequestRequestViewModel, CancelVacationRequestResponseViewModel>
    {
        public CancelVacationRequestEndPoint(EndpointBaseParameters<CancelVacationRequestRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CancelVacationRequest })]
        public async Task<EndPointResponse<CancelVacationRequestResponseViewModel>> CancelVacationRequest(CancelVacationRequestRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CancelVacationRequestCommand>());
            if (result.IsSuccess)
                return EndPointResponse<CancelVacationRequestResponseViewModel>.Success(new CancelVacationRequestResponseViewModel(), "Vacation Request Canceled Successfully");
            else
                return EndPointResponse<CancelVacationRequestResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
