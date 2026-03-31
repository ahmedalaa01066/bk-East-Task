using EasyTask.Common.Endpoints;
using EasyTask.Features.Departments.EditDepartment.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Departments.EditDepartment
{
    public class EditDepartmentEndPoint : EndpointBase<EditDepartmentRequestViewModel, EditDepartmentResponseViewModel>
    {
        public EditDepartmentEndPoint(EndpointBaseParameters<EditDepartmentRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.EditDepartment })]
        public async Task<EndPointResponse<EditDepartmentResponseViewModel>> EditDepartment(EditDepartmentRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<EditDepartmentCommand>());
            if (result.IsSuccess)
                return EndPointResponse<EditDepartmentResponseViewModel>.Success(new EditDepartmentResponseViewModel(), "Department Updated Successfully");
            else
                return EndPointResponse<EditDepartmentResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
