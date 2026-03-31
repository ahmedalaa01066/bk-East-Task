using EasyTask.Common.Endpoints;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Managements.DTOs;
using EasyTask.Features.Common.Managements.Queries;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Managements.GetManagementByName
{
    public class GetAllManagementsEndPoint : EndpointBase<GetAllManagementsRequestViewModel, GetAllManagementsResponseViewModel>
    {
        public GetAllManagementsEndPoint(EndpointBaseParameters<GetAllManagementsRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.GetAllManagements })]
        public async Task<EndPointResponse<PagingViewModel<GetAllManagementsResponseViewModel>>> GetAllManagements([FromQuery] GetAllManagementsRequestViewModel viewModel)
        {


            var result = await _mediator.Send(viewModel.MapOne<GetAllManagementsQuery>());
            var response = result.Data.MapPage<GetManagementDTO, GetAllManagementsResponseViewModel>();

            if (result.IsSuccess && result.Data != null)
                return EndPointResponse<PagingViewModel<GetAllManagementsResponseViewModel>>.Success(response, "Managements Filtered Successfully");
            else
                return EndPointResponse<PagingViewModel<GetAllManagementsResponseViewModel>>.Failure(result.ErrorCode);

        }
    }
}
