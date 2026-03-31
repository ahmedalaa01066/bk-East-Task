using EasyTask.Common.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;
using EasyTask.Features.Levels.AddLevel.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Levels.AddLevel
{
    public class AddLevelEndpoint : EndpointBase<AddLevelRequestViewModel, AddLevelResponseViewModel>
    {
        public AddLevelEndpoint(EndpointBaseParameters<AddLevelRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.AddLevel })]
        public async Task<EndPointResponse<AddLevelResponseViewModel>> Post(AddLevelRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<AddLevelCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<AddLevelResponseViewModel>.Success(new AddLevelResponseViewModel(), "Level Added successfully.");
            }
            return EndPointResponse<AddLevelResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
