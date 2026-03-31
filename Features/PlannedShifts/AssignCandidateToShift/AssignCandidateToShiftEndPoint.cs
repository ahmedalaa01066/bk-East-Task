using EasyTask.Common.Endpoints;
using EasyTask.Features.PlannedShifts.AssignCandidateToShift.Orchestartor;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PlannedShifts.AssignCandidateToShift
{
    public class AssignCandidateToShiftEndPoint : EndpointBase<AssignCandidateToShiftRequestViewModel, AssignCandidateToShiftResponseViewModel>
    {
        public AssignCandidateToShiftEndPoint(EndpointBaseParameters<AssignCandidateToShiftRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AssignCandidateToShift })]
        public async Task<EndPointResponse<AssignCandidateToShiftResponseViewModel>> AssignCandidateToShift(AssignCandidateToShiftRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AssignCandidateToShiftOrchestartor>());

            if (result.IsSuccess)
                return EndPointResponse<AssignCandidateToShiftResponseViewModel>.Success(new AssignCandidateToShiftResponseViewModel(), "Candidate Assigned to Shift Successfully");
            else
                return EndPointResponse<AssignCandidateToShiftResponseViewModel>.Failure(result.ErrorCode,result.Message);
        }
    }
}
