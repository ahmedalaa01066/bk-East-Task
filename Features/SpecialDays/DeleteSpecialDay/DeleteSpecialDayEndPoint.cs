using EasyTask.Common.Endpoints;
using EasyTask.Features.SpecialDays.DeleteSpecialDay.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.SpecialDays.DeleteSpecialDay
{
    public class DeleteSpecialDayEndPoint : EndpointBase<DeleteSpecialDayRequestViewModel, DeleteSpecialDayResponseViewModel>
    {
        public DeleteSpecialDayEndPoint(EndpointBaseParameters<DeleteSpecialDayRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteSpecialDay })]
        public async Task<EndPointResponse<DeleteSpecialDayResponseViewModel>> DeleteSpecialDay(DeleteSpecialDayRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteSpecialDayCommand>());
            if (result.IsSuccess)
                return EndPointResponse<DeleteSpecialDayResponseViewModel>.Success(new DeleteSpecialDayResponseViewModel(), "Special Day Deleted Successfully");
            else
                return EndPointResponse<DeleteSpecialDayResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
