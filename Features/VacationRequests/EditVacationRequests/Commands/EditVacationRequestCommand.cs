using EasyTask.Common.Requests;
using EasyTask.Models.VacationRequests;

namespace EasyTask.Features.VacationRequests.EditVacationRequest.Commands
{
    public record EditVacationRequestCommand(string ID, DateOnly FromDate, DateOnly ToDate, string VacationId) : IRequestBase<bool>;
    public class EditVacationRequestCommandHandler : RequestHandlerBase<VacationRequest, EditVacationRequestCommand, bool>
    {
        public EditVacationRequestCommandHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditVacationRequestCommand request, CancellationToken cancellationToken)
        {

            var VacationRequest = new VacationRequest
            {
                ID = request.ID,
                FromDate = request.FromDate,
                ToDate = request.ToDate,
                VacationId=request.VacationId
            };

            _repository.SaveIncluded(VacationRequest, nameof(VacationRequest.FromDate),
                nameof(VacationRequest.ToDate));

            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
