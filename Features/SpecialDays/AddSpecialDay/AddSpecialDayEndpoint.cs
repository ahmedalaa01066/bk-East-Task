using EasyTask.Common.Endpoints;
using EasyTask.Features.SpecialDays.AddSpecialDay.Command;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.SpecialDays.AddSpecialDay
{
    public class AddSpecialDayEndpoint : EndpointBase<AddSpecialDayRequestViewModel, AddSpecialDayResponseViewModel>
    {
        public AddSpecialDayEndpoint(EndpointBaseParameters<AddSpecialDayRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AddSpecialDay })]
        public async Task<EndPointResponse<AddSpecialDayResponseViewModel>> AddSpecialDay(AddSpecialDayRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AddSpecialDayCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<AddSpecialDayResponseViewModel>.Success(new AddSpecialDayResponseViewModel(), "Special Day Added successfully.");
            }
            return EndPointResponse<AddSpecialDayResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
