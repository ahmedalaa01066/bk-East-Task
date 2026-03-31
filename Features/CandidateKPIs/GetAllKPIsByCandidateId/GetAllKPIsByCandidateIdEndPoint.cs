using EasyTask.Common.Endpoints;
using EasyTask.Common.Enums;
using EasyTask.Features.Common.CandidateKPIs.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidateKPIs.GetAllKPIsByCandidateId
{
    public class GetAllKPIsByCandidateIdEndPoint : EndpointBase<GetAllKPIsByCandidateIdRequestViewModel, GetAllKPIsByCandidateIdResponseViewModel>
    {
        public GetAllKPIsByCandidateIdEndPoint(EndpointBaseParameters<GetAllKPIsByCandidateIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllKPIsByCandidateId })]
        public async Task<ActionResult<EndPointResponse<List<GetAllKPIsByCandidateIdResponseViewModel>>>> GetAllKPIsByCandidateId(
         [FromQuery] GetAllKPIsByCandidateIdRequestViewModel? filter)
        {

            var result = await _mediator.Send(filter.MapOne<GetAllKPIsByCandidateIdQuery>());
            if (!result.IsSuccess || result.Data is null)
            {
                return EndPointResponse<List<GetAllKPIsByCandidateIdResponseViewModel>>
               .Failure(ErrorCode.NotFound, "No KPIs found for this candidate.");
            }
            var response = result.Data.MapList<GetAllKPIsByCandidateIdResponseViewModel>().ToList();

            return EndPointResponse<List<GetAllKPIsByCandidateIdResponseViewModel>>
                    .Success(response, "Candidate KPIs retrieved successfully.");
           
        }
    }
}
