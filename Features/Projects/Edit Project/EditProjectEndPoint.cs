using EasyTask.Common.Endpoints;
using EasyTask.Features.Projects.Edit_Project.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Projects.Edit_Project
{
    public class EditProjectEndPoint : EndpointBase<EditProjectRequestViewModel, EditProjectResponseViewModel>
    {
        public EditProjectEndPoint(EndpointBaseParameters<EditProjectRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditProject })]
        public async Task<EndPointResponse<EditProjectResponseViewModel>> EditProject(EditProjectRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(viewModel.MapOne<EditProjectCommand>());

            if (result.IsSuccess)
                return EndPointResponse<EditProjectResponseViewModel>.Success(new EditProjectResponseViewModel(), "Project Updated successfully");
            else
                return EndPointResponse<EditProjectResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
