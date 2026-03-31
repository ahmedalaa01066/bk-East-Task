using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.VacationRequests;

namespace EasyTask.Features.VacationRequests.RejectVacationRequest.Commands
{
    public record RejectVacationRequestCommand(string ID) : IRequestBase<bool>;
    public class RejectVacationRequestCommandHandler : RequestHandlerBase<VacationRequest, RejectVacationRequestCommand, bool>
    {
        public RejectVacationRequestCommandHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(RejectVacationRequestCommand request, CancellationToken cancellationToken)
        {
            var check = _repository.Get(r => r.ID == request.ID).FirstOrDefault();
            if (check == null)
            {
                return (RequestResult<bool>.Failure(ErrorCode.NotFound));
            }
            var Request = new VacationRequest
            {
                ID = request.ID,
                VacationRequestStatus = RequestStatus.Rejected,
            };
            _repository.SaveIncluded(Request, nameof(Request.VacationRequestStatus));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
