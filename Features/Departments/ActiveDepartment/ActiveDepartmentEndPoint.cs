using EasyTask.Common.Endpoints;
using EasyTask.Features.Departments.ActiveDepartment.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.Departments.ActiveDepartment
{
    public class ActiveDepartmentEndPoint : EndpointBase<ActiveDepartmentRequestViewModel, ActiveDepartmentResponseViewModel>
    {
        public ActiveDepartmentEndPoint(EndpointBaseParameters<ActiveDepartmentRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ActiveDepartment })]
        public async Task<EndPointResponse<ActiveDepartmentResponseViewModel>> Active(ActiveDepartmentRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<ActiveDepartmentCommand>());
            if (result.IsSuccess)
                return EndPointResponse<ActiveDepartmentResponseViewModel>.Success(new ActiveDepartmentResponseViewModel(), "Department Activated Successfully");
            else
                return EndPointResponse<ActiveDepartmentResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
