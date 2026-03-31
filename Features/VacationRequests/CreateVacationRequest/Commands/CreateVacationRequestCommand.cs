using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.VacationRequests;
using EasyTask.Models.Enums;

namespace EasyTask.Features.VacationRequests.CreateVacationRequest.Commands
{
    public record CreateVacationRequestCommand(string? CandidateId, string VacationId, DateOnly FromDate, DateOnly ToDate)
        : IRequestBase<bool>;
    public class CreateVacationRequestCommandHandler : RequestHandlerBase<VacationRequest, CreateVacationRequestCommand, bool>
    {
        public CreateVacationRequestCommandHandler(RequestHandlerBaseParameters<VacationRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateVacationRequestCommand request, CancellationToken cancellationToken)
        {
            var candidateId = request.CandidateId;

            if (string.IsNullOrEmpty(candidateId))
            {
                candidateId = _userState.UserID; 
            }

            if (string.IsNullOrEmpty(candidateId))
            {
                return RequestResult<bool>.Failure(ErrorCode.Unauthorize,"CandidateId is required.");
            }

            var vacation = new VacationRequest()
            {
                CandidateId = candidateId,
                VacationId = request.VacationId,
                FromDate = request.FromDate,
                ToDate = request.ToDate,
                VacationRequestStatus = RequestStatus.Pending,
            };

            _repository.Add(vacation);
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
