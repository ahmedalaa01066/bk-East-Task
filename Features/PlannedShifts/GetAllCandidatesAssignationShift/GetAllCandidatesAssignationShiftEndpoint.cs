using EasyTask.Common.Endpoints;
using EasyTask.Common.Views;
using EasyTask.Features.Common.PlannedShifts.DTOs;
using EasyTask.Features.Common.PlannedShifts.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.PlannedShifts.GetAllCandidatesAssignationShift
{
    public class GetAllCandidatesAssignationShiftEndpoint : EndpointBase<GetAllCandidatesAssignationShiftRequestViewModel, GetAllCandidatesAssignationShiftRespnseViewModel>
    {
        public GetAllCandidatesAssignationShiftEndpoint(EndpointBaseParameters<GetAllCandidatesAssignationShiftRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllCandidatesAssignation })]
        public async Task<EndPointResponse<PagingViewModel<GetAllCandidatesAssignationShiftRespnseViewModel>>> GetAllCandidatesAssignation([FromQuery] GetAllCandidatesAssignationShiftRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<GetAllCandidatesAssignationShiftQuery>());
            var response = result.Data.MapPage<GetAllCandidatesAssignationShiftDTO, GetAllCandidatesAssignationShiftRespnseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<PagingViewModel<GetAllCandidatesAssignationShiftRespnseViewModel>>.Success(response, "Get All Candidates Assignation Filtered Successfully");
            else
                return EndPointResponse<PagingViewModel<GetAllCandidatesAssignationShiftRespnseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
