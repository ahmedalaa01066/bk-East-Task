using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.PermissionRequests;

namespace EasyTask.Features.PermissionRequests.CreatePermissionRequest.Commands
{
    public record CreatePermissionRequestCommand(string? CandidateId, string PermissionId, DateOnly Date,
        TimeSpan FromTime, TimeSpan ToTime) : IRequestBase<bool>;
    public class CreatePermissionRequestCommandHandler : RequestHandlerBase<PermissionRequest, CreatePermissionRequestCommand, bool>
    {
        public CreatePermissionRequestCommandHandler(RequestHandlerBaseParameters<PermissionRequest> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreatePermissionRequestCommand request, CancellationToken cancellationToken)
        {
            var candidateId = request.CandidateId;

            if (string.IsNullOrEmpty(candidateId))
            {
                candidateId = _userState.UserID;
            }

            if (string.IsNullOrEmpty(candidateId))
            {
                return RequestResult<bool>.Failure(ErrorCode.Unauthorize, "CandidateId is required.");
            }

            var permission = new PermissionRequest()
            {
                CandidateId = candidateId,
                PermissionId = request.PermissionId,
                Date = request.Date,
                FromTime = request.FromTime,
                ToTime = request.ToTime,
                PermissionRequestStatus = RequestStatus.Pending
            };

            _repository.Add(permission);
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
