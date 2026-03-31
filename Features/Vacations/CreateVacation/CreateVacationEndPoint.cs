using EasyTask.Common.Endpoints;
using EasyTask.Features.Vacations.CreateVacation.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Vacations.CreateVacation
{
    public class CreateVacationEndPoint : EndpointBase<CreateVacationRequestViewModel, CreateVacationResponseViewModel>
    {
        public CreateVacationEndPoint(EndpointBaseParameters<CreateVacationRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateVacation })]
        public async Task<EndPointResponse<CreateVacationResponseViewModel>> CreateVacation(CreateVacationRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateVacationCommand>());
            if (result.IsSuccess)
                return EndPointResponse<CreateVacationResponseViewModel>.Success(new CreateVacationResponseViewModel(), "Vacation Added Successfully");
            else
                return EndPointResponse<CreateVacationResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
