using EasyTask.Common.Endpoints;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Users.DTOs;
using EasyTask.Features.Common.Users.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Users.GetAllVerifiedStatus
{
    public class GetAllVerifiedStatusEndPoint : EndpointBase<GetAllVerifiedStatusRequestViewModel, GetAllVerifiedStatusResponseViewModel>
    {
        public GetAllVerifiedStatusEndPoint(EndpointBaseParameters<GetAllVerifiedStatusRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllVerifiedStatus })]
        public async Task<EndPointResponse<PagingViewModel<GetAllVerifiedStatusResponseViewModel>>> GetList([FromQuery] GetAllVerifiedStatusRequestViewModel viewModel)
        {

            var result = await _mediator.Send(viewModel.MapOne<GetAllVerifiedStatusQuery>());

            var response = result.Data.MapPage< VerifiedStatusDTO, GetAllVerifiedStatusResponseViewModel >();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<PagingViewModel<GetAllVerifiedStatusResponseViewModel>>.Success(response, "get verified list successfully.");
            else
                return EndPointResponse<PagingViewModel<GetAllVerifiedStatusResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
