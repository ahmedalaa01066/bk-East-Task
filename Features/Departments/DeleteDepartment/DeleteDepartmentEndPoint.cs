using EasyTask.Common.Endpoints;
using EasyTask.Features.Departments.DeleteDepartment.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Departments.DeleteDepartment
{
    public class DeleteDepartmentEndPoint : EndpointBase<DeleteDepartmentRequestViewModel, DeleteDepartmentResponseViewModel>
    {
        public DeleteDepartmentEndPoint(EndpointBaseParameters<DeleteDepartmentRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpDelete]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeleteDepartment })]
        public async Task<EndPointResponse<DeleteDepartmentResponseViewModel>> DeleteDepartment(DeleteDepartmentRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);

            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeleteDepartmentCommand>());
            if (result.IsSuccess)
            {
                return EndPointResponse<DeleteDepartmentResponseViewModel>.Success(new DeleteDepartmentResponseViewModel(), "Department Deleted successfully.");
            }
            return EndPointResponse<DeleteDepartmentResponseViewModel>.Failure(result.ErrorCode);

        }
    }
}
