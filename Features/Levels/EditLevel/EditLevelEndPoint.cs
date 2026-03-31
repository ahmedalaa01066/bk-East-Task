using EasyTask.Common.Endpoints;
using EasyTask.Features.Levels.EditLevel.Commands;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using EasyTask.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Levels.EditLevel
{
    public class EditLevelEndPoint : EndpointBase<EditLevelRequestViewModel, EditLevelResponseViewModel>
    {
        public EditLevelEndPoint(EndpointBaseParameters<EditLevelRequestViewModel> dependencyCollection)
            : base(dependencyCollection)
        {
        }

        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditLevel })]
        public async Task<EndPointResponse<EditLevelResponseViewModel>> EditLevel(EditLevelRequestViewModel viewModel)
        {

            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<EditLevelCommand>());

            if (result.IsSuccess)
            {
                return EndPointResponse<EditLevelResponseViewModel>.Success(
                    new EditLevelResponseViewModel(), "Level Updated Successfully");
            }

            return EndPointResponse<EditLevelResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}