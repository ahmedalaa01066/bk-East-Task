using EasyTask.Common.Endpoints;
using EasyTask.Features.Vacations.DeleteVacation.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Vacations.DeleteVacation
{
    public class DeleteVacationEndpoint : EndpointBase<DeleteVacationRequestViewModel, DeleteVacationResponseViewModel>
    {
        public DeleteVacationEndpoint(EndpointBaseParameters<DeleteVacationRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteVacation })]
        public async Task<EndPointResponse<DeleteVacationResponseViewModel>> DeleteVacation(DeleteVacationRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteVacationCommand>());
            if (result.IsSuccess)
                return EndPointResponse<DeleteVacationResponseViewModel>.Success(new DeleteVacationResponseViewModel(), "Vacation Deleted Successfully");
            else
                return EndPointResponse<DeleteVacationResponseViewModel>.Failure(result.ErrorCode);
        }

    }
}
