using EasyTask.Common.Endpoints;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Penalities.DTOs;
using EasyTask.Features.Common.Penalities.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Penalities.GetPenalitiesByCandidateId
{
    public class GetPenalitiesByCandidateIdEndpoint : EndpointBase<GetPenalitiesByCandidateIdRequestViewModel, GetPenalitiesByCandidateIdResponseViewModel>
    {
        public GetPenalitiesByCandidateIdEndpoint(EndpointBaseParameters<GetPenalitiesByCandidateIdRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllPenalitiesByCandidateId })]
        public async Task<EndPointResponse<PagingViewModel<GetPenalitiesByCandidateIdResponseViewModel>>> GetAllPenalitiesByCandidateId([FromQuery] GetPenalitiesByCandidateIdRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<GetPenalitiesByCandidateIdQuery>());

            var response = result.Data.MapPage<GetPenalitiesByCandidateIdDTO, GetPenalitiesByCandidateIdResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<PagingViewModel<GetPenalitiesByCandidateIdResponseViewModel>>.Success(response, "Get All Penalities successfully.");
            else
                return EndPointResponse<PagingViewModel<GetPenalitiesByCandidateIdResponseViewModel>>.Failure(result.ErrorCode);


        }
    }
}
