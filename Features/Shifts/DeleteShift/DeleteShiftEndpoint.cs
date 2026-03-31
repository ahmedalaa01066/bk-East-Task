using EasyTask.Common.Endpoints;
using EasyTask.Features.Shifts.DeleteShift.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Shifts.DeleteShift
{
    public class DeleteShiftEndpoint : EndpointBase<DeleteShiftRequestViewModel, DeleteShiftResponseViewModel>
    {
        public DeleteShiftEndpoint(EndpointBaseParameters<DeleteShiftRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }

        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteShift })]
        public async Task<EndPointResponse<DeleteShiftResponseViewModel>> Delete(DeleteShiftRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteShiftCommand>());
            if (result.IsSuccess)
                return EndPointResponse<DeleteShiftResponseViewModel>.Success(new DeleteShiftResponseViewModel(), "Shift Deleted Successfully");
            else
                return EndPointResponse<DeleteShiftResponseViewModel>.Failure(result.ErrorCode);
        }

    }
}
