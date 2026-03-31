using EasyTask.Common.Endpoints;
using EasyTask.Features.CandidateCourses.SetActualStartDate.Commands;
using EasyTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Roboost.Common.Views;

namespace EasyTask.Features.CandidateCourses.SetActualStartDate
{
    public class SetActualStartDateEndPoint : EndpointBase<SetActualStartDateRequestViewModel, SetActualStartDateResponseViewModel>
    {
        public SetActualStartDateEndPoint(EndpointBaseParameters<SetActualStartDateRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPut]
        //[TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.SetActualStartDate })]
        public async Task<EndPointResponse<SetActualStartDateResponseViewModel>> SetActualStartDate(SetActualStartDateRequestViewModel viewModel)
        {
            var validationResult = await ValidateRequestAsync(viewModel);
            if (!validationResult.IsSuccess)
                return validationResult;
            var result = await _mediator.Send(viewModel.MapOne<SetActualStartDateCommand>());
            if (result.IsSuccess)
                return EndPointResponse<SetActualStartDateResponseViewModel>.Success(new SetActualStartDateResponseViewModel(), "Course Updated Successfully");
            else
                return EndPointResponse<SetActualStartDateResponseViewModel>.Failure(result.ErrorCode);
        }
    }


}
