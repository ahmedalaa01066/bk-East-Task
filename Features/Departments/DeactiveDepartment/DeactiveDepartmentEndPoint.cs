using EasyTask.Common.Endpoints;
using EasyTask.Features.Departments.DeactiveDepartment.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Departments.DeactiveDepartment
{
    public class DeactiveDepartmentEndPoint : EndpointBase<DeactiveDepartmentRequestViewModel, DeactiveDepartmentResponseViewModel>
    {
        public DeactiveDepartmentEndPoint(EndpointBaseParameters<DeactiveDepartmentRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.DeactiveDepartment })]
        public async Task<EndPointResponse<DeactiveDepartmentResponseViewModel>> Deactive(DeactiveDepartmentRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<DeactiveDepartmentCommand>());
            if (result.IsSuccess)
                return EndPointResponse<DeactiveDepartmentResponseViewModel>.Success(new DeactiveDepartmentResponseViewModel(), "Department Deactivated Successfully");
            else
                return EndPointResponse<DeactiveDepartmentResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
