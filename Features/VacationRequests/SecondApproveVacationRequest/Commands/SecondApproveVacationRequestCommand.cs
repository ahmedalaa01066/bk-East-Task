using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.VacationRequests;

namespace EasyTask.Features.VacationRequests.SecondApproveVactionRequest.Commands
{
    public record SecondApproveVacationRequestCommand(string ID) : IRequestBase<bool>;
    public class SecondApproveVacationRequestCommandHandler : RequestHandlerBase<VacationRequest, SecondApproveVacationRequestCommand, bool>
    {
        public SecondApproveVacationRequestCommandHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(SecondApproveVacationRequestCommand request, CancellationToken cancellationToken)
        {
            var check = _repository.Get(r => r.ID == request.ID).FirstOrDefault();
            if (check == null)
            {
                return (RequestResult<bool>.Failure(ErrorCode.NotFound));
            }
            var Request = new VacationRequest
            {
                ID = request.ID,
                VacationRequestStatus = RequestStatus.SecondApproval,
            };
            _repository.SaveIncluded(Request, nameof(Request.VacationRequestStatus));
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
