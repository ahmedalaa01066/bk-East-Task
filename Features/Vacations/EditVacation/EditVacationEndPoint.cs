using EasyTask.Common.Endpoints;
using EasyTask.Features.Vacations.EditVacation.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Vacations.EditVacation
{
    public class EditVacationEndPoint : EndpointBase<EditVacationRequestViewModel, EditVacationResponseViewModel>
    {
        public EditVacationEndPoint(EndpointBaseParameters<EditVacationRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditVacation })]
        public async Task<EndPointResponse<EditVacationResponseViewModel>> EditVacation(EditVacationRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditVacationCommand>());
            if (result.IsSuccess)
                return EndPointResponse<EditVacationResponseViewModel>.Success(new EditVacationResponseViewModel(), "Vacation Edit Successfully");
            else
                return EndPointResponse<EditVacationResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
