using EasyTask.Common.Endpoints;
using EasyTask.Features.Penalities.AddPenality.Command;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Penalities.AddPenality
{
    public class AddPenalityEndPoint : EndpointBase<AddPenalityRequestViewModel, AddPenalityResponseViewModel>
    {
        public AddPenalityEndPoint(EndpointBaseParameters<AddPenalityRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AddPenality })]
        public async Task<EndPointResponse<AddPenalityResponseViewModel>> AddPenality(AddPenalityRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AddPenalityCommand>());
            if (result.IsSuccess)
                return EndPointResponse<AddPenalityResponseViewModel>.Success(new AddPenalityResponseViewModel(), "Penality Added Successfully");
            else
                return EndPointResponse<AddPenalityResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
