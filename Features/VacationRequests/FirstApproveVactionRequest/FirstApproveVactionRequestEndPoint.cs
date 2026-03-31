using EasyTask.Common.Endpoints;
using EasyTask.Features.VacationRequests.FirstApproveVactionRequest.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.VacationRequests.FirstApproveVactionRequest
{
    public class FirstApproveVactionRequestEndPoint : EndpointBase<FirstApproveVactionRequestRequestViewModel, FirstApproveVactionRequestResponseViewModel>
    {
        public FirstApproveVactionRequestEndPoint(EndpointBaseParameters<FirstApproveVactionRequestRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.FirstApproveVactionRequest })]
        public async Task<EndPointResponse<FirstApproveVactionRequestResponseViewModel>> FirstApproveVactionRequest(FirstApproveVactionRequestRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<FirstApproveVactionRequestCommand>());
            if (result.IsSuccess)
                return EndPointResponse<FirstApproveVactionRequestResponseViewModel>.Success(new FirstApproveVactionRequestResponseViewModel(), "Vacation Request Approved Successfully");
            else
                return EndPointResponse<FirstApproveVactionRequestResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
