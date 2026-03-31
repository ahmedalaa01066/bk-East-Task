using EasyTask.Common.Endpoints;
using EasyTask.Features.Attendances.EndAttendance.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Attendances.EndAttendance
{
    public class EndAttendanceEndPoint : EndpointBase<EndAttendanceRequestViewModel, EndAttendanceResponseViewModel>
    {
        public EndAttendanceEndPoint(EndpointBaseParameters<EndAttendanceRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditAttendance })]
        public async Task<EndPointResponse<EndAttendanceResponseViewModel>> EndAttendance(EndAttendanceRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<EndAttendanceCommand>());

            if (result.IsSuccess)
                return EndPointResponse<EndAttendanceResponseViewModel>.Success(new EndAttendanceResponseViewModel(), "Candidate log out ");
            else
                return EndPointResponse<EndAttendanceResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
