using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Common.Views;
using EasyTask.Features.Common.CandidatePermissions.DTOs;
using EasyTask.Features.Common.CandidatePermissions.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidatePermissions.GetAllCandidatePermissions
{
    public class GetAllCandidatePermissionsEndpoint : EndpointBase<GetAllCandidatePermissionsRequestViewModel, GetAllCandidatePermissionsResponseViewModel>
    {
        public GetAllCandidatePermissionsEndpoint(EndpointBaseParameters<GetAllCandidatePermissionsRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllCandidatePermissions })]
        public async Task<ActionResult<EndPointResponse<PagingViewModel<GetAllCandidatePermissionsResponseViewModel>>>> GetAllCandidatePermissions(
            [FromQuery] GetAllCandidatePermissionsRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllCandidatePermissionsQuery>());
            var response = result.Data.MapPage<GetAllCandidatePermissionsDTO, GetAllCandidatePermissionsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
            {

                return EndPointResponse<PagingViewModel<GetAllCandidatePermissionsResponseViewModel>>
                    .Success(response, "Candidates Permissions filtered successfully.");
            }

            return EndPointResponse<PagingViewModel<GetAllCandidatePermissionsResponseViewModel>>
                .Failure(ErrorCode.NotFound);

        }
    }
}