using EasyTask.Common.Endpoints;
using EasyTask.Features.VacationRequests.EditVacationRequest.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.VacationRequests.EditVacationRequest
{
    public class EditVacationRequestEndPoint : EndpointBase<EditVacationRequestRequestViewModel, EditVacationRequestResponseViewModel>
    {
        public EditVacationRequestEndPoint(EndpointBaseParameters<EditVacationRequestRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditVacationRequest })]
        public async Task<EndPointResponse<EditVacationRequestResponseViewModel>> EditVacationRequest(EditVacationRequestRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<EditVacationRequestCommand>());

            if (result.IsSuccess)
                return EndPointResponse<EditVacationRequestResponseViewModel>.Success(new EditVacationRequestResponseViewModel(), "Request Updated successfully");
            else
                return EndPointResponse<EditVacationRequestResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
