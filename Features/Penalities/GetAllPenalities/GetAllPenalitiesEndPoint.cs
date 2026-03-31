using EasyTask.Common.Endpoints;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Penalities.DTOs;
using EasyTask.Features.Common.Penalities.Queries;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Penalities.GetAllPenalities
{
    public class GetAllPenalitiesEndPoint : EndpointBase<GetAllPenalitiesRequestViewModel, GetAllPenalitiesResponseViewModel>
    {
        public GetAllPenalitiesEndPoint(EndpointBaseParameters<GetAllPenalitiesRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllPenalities })]
        public async Task<EndPointResponse<PagingViewModel<GetAllPenalitiesResponseViewModel>>> GetAllPenalities([FromQuery] GetAllPenalitiesRequestViewModel viewModel)
        {
            var result = await _mediator.Send(viewModel.MapOne<GetAllPenalitiesQuery>());

            var response = result.Data.MapPage<GetAllPenalitiesDTO, GetAllPenalitiesResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<PagingViewModel<GetAllPenalitiesResponseViewModel>>.Success(response, "Get All Penalities successfully.");
            else
                return EndPointResponse<PagingViewModel<GetAllPenalitiesResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
