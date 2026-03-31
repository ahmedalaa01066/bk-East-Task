using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.CandidatePermissions;

namespace EasyTask.Features.CandidatePermissions.CreateCandidatePermission.Commands
{
    public record EditEditCandidatePermissionCommand(
        string ID,
        TimeSpan? NumOfHoursOfPermission,
        TimeSpan HoursLeftInMonth
    ) : IRequestBase<string>;
    public class CreateEditCandidatePermissionCommandHandler : RequestHandlerBase<CandidatePermission, EditEditCandidatePermissionCommand, string>
    {
        public CreateEditCandidatePermissionCommandHandler(RequestHandlerBaseParameters<CandidatePermission> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(EditEditCandidatePermissionCommand request, CancellationToken cancellationToken)
        {
            var existingCandidatePermission = _repository.GetByID(request.ID);

            if (existingCandidatePermission == null)
                RequestResult<string>.Failure(ErrorCode.NotFound);

            existingCandidatePermission.NumOfHoursOfPermission = request.NumOfHoursOfPermission ?? existingCandidatePermission.NumOfHoursOfPermission;
            existingCandidatePermission.HoursLeftInMonth = request.HoursLeftInMonth;

            _repository.SaveIncluded(existingCandidatePermission,
                nameof(existingCandidatePermission.NumOfHoursOfPermission),nameof(existingCandidatePermission.HoursLeftInMonth));
            _repository.SaveChanges();
            return RequestResult<string>.Success(existingCandidatePermission.ID);
        }
    }
}
