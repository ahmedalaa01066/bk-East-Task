using EasyTask.Common.Endpoints;
using EasyTask.Features.Shifts.EditShift.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Shifts.EditShift
{
    public class EditShiftEndPoint : EndpointBase<EditShiftRequestViewModel, EditShiftResponseViewModel>
    {
        public EditShiftEndPoint(EndpointBaseParameters<EditShiftRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditShift })]
        public async Task<EndPointResponse<EditShiftResponseViewModel>> EditShift(EditShiftRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditShiftCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<EditShiftResponseViewModel>.Success(new EditShiftResponseViewModel(), "Shift Edited successfully.");
            }
            return EndPointResponse<EditShiftResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
