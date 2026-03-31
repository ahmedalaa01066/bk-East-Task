using EasyTask.Common.Endpoints;
using EasyTask.Features.Shifts.CreateShift.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Shifts.CreateShift
{
    public class CreateShiftEndPoint : EndpointBase<CreateShiftRequestViewModel, CreateShiftResponseViewModel>
    {
        public CreateShiftEndPoint(EndpointBaseParameters<CreateShiftRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateShift })]
        public async Task<EndPointResponse<CreateShiftResponseViewModel>> CreateShift(CreateShiftRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<CreateShiftCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<CreateShiftResponseViewModel>.Success(new CreateShiftResponseViewModel(), "Shift Added successfully.");
            }
            return EndPointResponse<CreateShiftResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
