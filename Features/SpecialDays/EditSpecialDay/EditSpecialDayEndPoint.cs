using EasyTask.Common.Endpoints;
using EasyTask.Features.SpecialDays.EditSpecialDay.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.SpecialDays.EditSpecialDay
{
    public class EditSpecialDayEndPoint : EndpointBase<EditSpecialDayRequestViewModel, EditSpecialDayResponseViewModel>
    {
        public EditSpecialDayEndPoint(EndpointBaseParameters<EditSpecialDayRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditSpecialDay })]
        public async Task<EndPointResponse<EditSpecialDayResponseViewModel>> EditSpecialDay(EditSpecialDayRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditSpecialDayCommand>());
            if (result.IsSuccess)
                return EndPointResponse<EditSpecialDayResponseViewModel>.Success(new EditSpecialDayResponseViewModel(), "SpecialDay Updated Successfully");
            else
                return EndPointResponse<EditSpecialDayResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
