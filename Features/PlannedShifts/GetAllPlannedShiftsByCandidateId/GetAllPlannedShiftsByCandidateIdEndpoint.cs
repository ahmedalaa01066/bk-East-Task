using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.PlannedShifts.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PlannedShifts.GetAllPlannedShiftsByCandidateId
{
    public class GetAllPlannedShiftsByCandidateIdEndpoint : EndpointBase<GetAllPlannedShiftsByCandidateIdRequestViewModel, GetAllPlannedShiftsByCandidateIdRespnseViewModel>
    {
        public GetAllPlannedShiftsByCandidateIdEndpoint(EndpointBaseParameters<GetAllPlannedShiftsByCandidateIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllPlannedShiftsByCandidateId })]
        public async Task<EndPointResponse<List<GetAllPlannedShiftsByCandidateIdRespnseViewModel>>> GetAllPlannedShiftsByCandidateId([FromQuery] GetAllPlannedShiftsByCandidateIdRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<GetAllPlannedShiftsByCandidateIdQuery>());
            var response = result.Data.MapList<GetAllPlannedShiftsByCandidateIdRespnseViewModel>().ToList();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<List<GetAllPlannedShiftsByCandidateIdRespnseViewModel>>.Success(response, "Get All Planned Shifts for Candidates Successfully");
            else
                return EndPointResponse<List<GetAllPlannedShiftsByCandidateIdRespnseViewModel>>.Failure(result.ErrorCode);
        }
    }
}
