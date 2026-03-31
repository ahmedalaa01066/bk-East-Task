using EasyTask.Common.Endpoints;
using EasyTask.Features.CandidateVacations.UpdateCandidateVacationDays.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidateVacations.UpdateCandidateVacationDays
{
    public class UpdateCandidateVacationDaysEndpoint : EndpointBase<UpdateCandidateVacationDaysRequestViewModel, UpdateCandidateVacationDaysResponseViewModel>
    {
        public UpdateCandidateVacationDaysEndpoint(EndpointBaseParameters<UpdateCandidateVacationDaysRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.UpdateCandidateVacationDays })]
        public async Task<EndPointResponse<UpdateCandidateVacationDaysResponseViewModel>> UpdateCandidateVacationDays(UpdateCandidateVacationDaysRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<UpdateCandidateVacationDaysCommand>());

            if (result.IsSuccess)
                return EndPointResponse<UpdateCandidateVacationDaysResponseViewModel>.Success(new UpdateCandidateVacationDaysResponseViewModel(), "Candidate Vacation Days Updated successfully");
            else
                return EndPointResponse<UpdateCandidateVacationDaysResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
