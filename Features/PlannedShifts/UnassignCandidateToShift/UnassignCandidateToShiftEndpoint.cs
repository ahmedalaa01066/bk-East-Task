using EasyTask.Common.Endpoints;
using EasyTask.Features.PlannedShifts.UnassignCandidateToShift.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PlannedShifts.UnassignCandidateToShift
{
    public class UnassignCandidateToShiftEndpoint : EndpointBase<UnassignCandidateToShiftRequestViewModel, UnassignCandidateToShiftResponseViewModel>
    {
        public UnassignCandidateToShiftEndpoint(EndpointBaseParameters<UnassignCandidateToShiftRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.UnassignCandidateToShift })]
        public async Task<EndPointResponse<UnassignCandidateToShiftResponseViewModel>> UnassignCandidateToShift( UnassignCandidateToShiftRequestViewModel viewModel)
        {

            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<UnassignCandidateToShiftCommand>());
            if (result.IsSuccess)
                return EndPointResponse<UnassignCandidateToShiftResponseViewModel>.Success(new UnassignCandidateToShiftResponseViewModel(), "Unassign Candidate to Shift Successfully");
            else
                return EndPointResponse<UnassignCandidateToShiftResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
