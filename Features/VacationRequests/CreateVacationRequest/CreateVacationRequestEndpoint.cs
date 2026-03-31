using EasyTask.Common.Endpoints;
using EasyTask.Features.VacationRequests.CreateVacationRequest.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.VacationRequests.CreateVacationRequest
{
    public class CreateVacationRequestEndpoint : EndpointBase<CreateVacationRequestRequestViewModel, CreateVacationRequestResponseViewModel>
    {
        public CreateVacationRequestEndpoint(EndpointBaseParameters<CreateVacationRequestRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateVacationRequest })]
        public async Task<EndPointResponse<CreateVacationRequestResponseViewModel>> CreateVacationRequest(CreateVacationRequestRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateVacationRequestCommand>());
            if (result.IsSuccess)
                return EndPointResponse<CreateVacationRequestResponseViewModel>.Success(new CreateVacationRequestResponseViewModel(), "Vacation Request Added Successfully");
            else
                return EndPointResponse<CreateVacationRequestResponseViewModel>.Failure(result.ErrorCode,result.Message);
        }

    }
}
