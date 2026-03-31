
using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.CandidateVacations.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidateVacations.GetCandidateVacationRemainingDays
{
    public class GetCandidateVacationRemainingDaysEndpoint : EndpointBase<GetCandidateVacationRemainingDaysRequestViewModel, GetCandidateVacationRemainingDaysResponseViewModel>
    {
        public GetCandidateVacationRemainingDaysEndpoint(EndpointBaseParameters<GetCandidateVacationRemainingDaysRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetCandidateVacationRemainingDays })]
        public async Task<EndPointResponse<GetCandidateVacationRemainingDaysResponseViewModel>> GetCandidateVacationRemainingDays([FromQuery] GetCandidateVacationRemainingDaysRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetCandidateVacationRemainingDaysQuery>());

            GetCandidateVacationRemainingDaysResponseViewModel response = result.Data.MapOne<GetCandidateVacationRemainingDaysResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<GetCandidateVacationRemainingDaysResponseViewModel>.Success(response, "Get Candidate Vacation Remaining Days successfully.");
            else
                return EndPointResponse<GetCandidateVacationRemainingDaysResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
