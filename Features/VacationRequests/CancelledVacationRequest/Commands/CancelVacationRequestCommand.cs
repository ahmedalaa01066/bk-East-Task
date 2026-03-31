using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.VacationRequests;

namespace EasyTask.Features.VacationRequests.CancelVacationRequest.Commands
{
    public record CancelVacationRequestCommand(string ID) : IRequestBase<bool>;
    public class CancelVacationRequestCommandHandler : RequestHandlerBase<VacationRequest, CancelVacationRequestCommand, bool>
    {
        public CancelVacationRequestCommandHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CancelVacationRequestCommand request, CancellationToken cancellationToken)
        {
            var check = _repository.Get(r => r.ID == request.ID).FirstOrDefault();
            if (check.VacationRequestStatus == RequestStatus.Pending)
            {
                if (check == null)
                {
                    return (RequestResult<bool>.Failure(ErrorCode.NotFound));
                }
                var Request = new VacationRequest
                {
                    ID = request.ID,
                    VacationRequestStatus = RequestStatus.Cancelled,
                };
                _repository.SaveIncluded(Request, nameof(Request.VacationRequestStatus));
                _repository.SaveChanges();
                return RequestResult<bool>.Success(true);
            }
            return RequestResult<bool>.Failure(ErrorCode.CannotCancel);
        }
    }
}
